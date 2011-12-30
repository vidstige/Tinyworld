using System;
using System.Linq;
using System.Collections.Generic;

namespace Smallworld
{
	internal class Player
	{
		private readonly IPlayer _player;
		private readonly Board _board;
		private readonly AvailableTribes _availableTribes;
		
		private int _coins = 5;	
		//private Tribe _inDecline;
		private Tribe _active;
		
		private int _tokensInHand;
		
		public Player(IPlayer player, Board board, AvailableTribes availableTribes)
		{
			_player = player;
			_board = board;
			_availableTribes = availableTribes;
		}
		
		public IEnumerable<Region> OccupiedRegions
		{
			get { return _board.Regions.Where(r => r.OccupiedBy(this)); }
		}
		
		public void SelectNewIfNeeded()
		{ 
			if (_active != null) return;
			_active = _player.SelectTribe(_availableTribes.Tribes);
			// TODO: Check so that _active is in _availableTribes.Tribes
			_availableTribes.Remove(_active);
			
			_tokensInHand = _active.StartingTokens;
			
			Console.WriteLine(_player.Name + " selected " + _active);
		}
		
		public void GatherTokens()
		{
			foreach (Region r in OccupiedRegions)
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
				Region r = _player.Conquer(availibleForConquer);
				
				if (r == null) return; // players may return null to end conquering..
				// TODO: Check so that r is in availibleForConquer
				
				if (r.RequiredTokens > _tokensInHand)
				{
					// TODO: Roll dice
					lastAttemptPerformed = true;
				}
				else
				{
					int conquerTokens = r.RequiredTokens;
					Console.WriteLine("{0} conquers a region using {1} tokens", _player.Name, conquerTokens);
					_tokensInHand -= conquerTokens;
					r.OccupyBy(this, conquerTokens);
				}
			}
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
				if (OccupiedRegions.Any()) 
				{
					return Regions.AdjecentTo(OccupiedRegions).Except(Edge).Where(Affordable);
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