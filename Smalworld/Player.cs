using System;
using System.Linq;
using System.Collections.Generic;

namespace Smallworld
{
	internal class Player
	{
		private readonly IPlayer _player;
		private readonly IGameListener _listener;
		private readonly Board _board;
		private readonly AvailableTribes _availableTribes;
		private readonly Dice _dice;
		
		private int _coins = 5;	
		private Tribe _active;
		private Tribe _declining;
		
		private int _tokensInHand;
		
		public Player(IPlayer player, IGameListener listener, Board board, AvailableTribes availableTribes, Dice dice)
		{
			if (player == null) throw new ArgumentNullException("player");
			_player = player;
			_listener = listener;
			_board = board;
			_availableTribes = availableTribes;
			_dice = dice;
		}

		public string Name { get { return _player.Name; } }
		
		public IEnumerable<Region> OccupiedRegions
		{
			get { return _board.Regions.Where(r => r.OccupiedBy(this)); }
		}
		
		private bool HasActiveTribe { get { return _active != null; } }
		private bool HasDecliningTribe { get { return _declining != null; } }
		
		public bool Declines()
		{
			if (!HasActiveTribe) return false;
			
			return _player.Declines();
		}
		
		public void Decline()
		{
			if (HasDecliningTribe)
			{
				// 1. Remove all declining tribe tokens
				foreach (var region in _board.Regions.Where(OccupiedByDecliningRace))
				{
					region.Extinct();
				}
			}

			// 2. Remove all but one active tribe tokens
			foreach (var region in RegionsOccupiedByActiveRace)
			{
				region.PickUpAllButOne();
			}
			
			// 3. Let the active become the declining
			_declining = _active;
			_active = null;

		}
		
		private IEnumerable<Region> RegionsOccupiedByActiveRace
		{
			get { return _board.Regions.Where(OccupiedByActiveRace); }
		}

		private bool OccupiedByActiveRace(Region r)
		{
			return r.OccupiedBy(this) && r.OccupiedBy(_active.Race);
		}
		
		private bool OccupiedByDecliningRace(Region r)
		{
			return r.OccupiedBy(this) && r.OccupiedBy(_declining.Race);
		}
		
		public void SelectNewIfNeeded()
		{ 
			if (HasActiveTribe) return;
			_active = _player.SelectTribe(_availableTribes.Tribes);
			_availableTribes.Remove(_active);
			_tokensInHand = _active.StartingTokens;
			_listener.PlayerSelectedTribe(_player, _active);
		}
		
		public void GatherTokens()
		{
			foreach (Region r in RegionsOccupiedByActiveRace)
			{
				int n = r.PickUpAllButOne();
				Console.WriteLine("{0} picks up {1} tokens", _player.Name, n);
				_tokensInHand += n;
			}
		}
		
		public void Conquer()
		{
			Console.WriteLine("{0} has {1} tokens in hand", _player.Name, _tokensInHand);
			
			bool lastAttemptPerformed = false;
			while (_tokensInHand > 0 && !lastAttemptPerformed)
			{
				IEnumerable<Region> availibleForConquer = AvailibleForConquer;
				Console.WriteLine("{0} has {1} regions to choose from...", _player.Name, availibleForConquer.Count());
				Region r = _player.Conquer(availibleForConquer);
				
				if (r == null) return; // players may return null to end conquering..
				// TODO: Check so that r is in availibleForConquer
				
				if (r.RequiredTokens > _tokensInHand)
				{
					Console.WriteLine("...needs to roll a {0}...", r.RequiredTokens - _tokensInHand);
					int result = _dice.Roll();
					if (_tokensInHand + result >= r.RequiredTokens)
					{
						Console.WriteLine("...and rolls a {0}", result);
						r.OccupyBy(this, _tokensInHand);
						_tokensInHand = 0;
					}
					else
					{
						Console.WriteLine("...but rolls a {0}", result);
					}
					lastAttemptPerformed = true;
				}
				else
				{
					int conquerTokens = r.RequiredTokens;
					Console.WriteLine("...and conquers a region using {1} tokens", _player.Name, conquerTokens);
					_tokensInHand -= conquerTokens;
					r.OccupyBy(this, conquerTokens);
				}
			}
		}
		
		public void GainCoins ()
		{
			int n = OccupiedRegions.Count();
			Console.WriteLine("{0} gains {1} coins", _player.Name, n);
			_coins += n;
		}

		public void PickUp(int tokens)
		{
			Console.WriteLine("{0} picks up {1} tokens", _player.Name, tokens);
			_tokensInHand += tokens;
		}
		
		public Tribe Active { get { return _active; } }
		public int Coins { get { return _coins; } }
		
		private IEnumerable<Region> AvailibleForConquer
		{
			get
			{
				if (_board.Regions.Where(OccupiedByActiveRace).Any()) 
				{
					return Regions.AdjecentTo(RegionsOccupiedByActiveRace).Except(Edge).Where(Affordable);
				}
				// first turn - Only edge adjecent regions are availible
				return _board.Edge.Adjecent.Where(Affordable);
			}
		}
	
		private bool Affordable(Region r)
		{
			return r.RequiredTokens <= _tokensInHand + Dice.MaxValue;
		}
		
		private IEnumerable<Region> Edge { get { yield return Region.Edge; } }
	}
}