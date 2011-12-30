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
		
		private int _coins;	
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
			get { return _board.Regions.Where(r => r.OccupiedBy(_active.Race)); }
		}
		
		public void SelectNewIfNeeded()
		{ 
			if (_active != null) return;
			_active = _player.SelectTribe(_availableTribes.Tribes);
			_tokensInHand = _active.StartingTokens;
			
			//Console.WriteLine("Player " + _player.Name + " selected " + _active);
		}
		
		public void GatherTokens()
		{
			foreach (Region r in OccupiedRegions)
			{
				_tokensInHand += r.PickUpAllButOne();
			}
		}
		
		public void Conquer()
		{
			bool lastAttemptPerformed = false;
			while (_tokensInHand > 0 && !lastAttemptPerformed)
			{
				IEnumerable<Region> availibleForConquer = AvailibleForConquer;
				Region r = _player.Conquer(availibleForConquer);
				
				if (r == null) return; // players may return null to end conquering..
				// TODO: Check so that r is in availibleForConquer
				
				if (r.RequiredTokens > _tokensInHand)
				{
					lastAttemptPerformed = true;
				}
				else
				{
					int conquerTokens = r.RequiredTokens;
					_tokensInHand -= conquerTokens;
					r.OccupyBy(_active.Race, conquerTokens);
				}
			}
		}
		
		public Tribe Active { get { return _active; } }
		public int Coins { get { return _coins; } }
		
		private IEnumerable<Region> AvailibleForConquer
		{
			get
			{
				if (OccupiedRegions.Any()) 
				{
					return Regions.AdjecentTo(OccupiedRegions).Except(Edge);
				}
				// first turn - Only edge adjecent regions are availible
				return _board.Edge.Adjecent;
			}
		}
		
		private IEnumerable<Region> Edge { get { yield return Region.Edge; } }
	}
}