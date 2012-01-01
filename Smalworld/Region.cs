using System;
using System.Collections.Generic;

namespace Smallworld
{
	public class Region
	{
		private readonly Terrain _terrain;
		private readonly IList<Region> _adjecent = new List<Region>();
		
		private Race _race;
		private int _tokens;
		private Player _occupyingPlayer;
		
		public static Region Edge = new Region(null);
		
		internal Region(Terrain terrain)
		{
			_terrain = terrain;
		}
		
		public int RequiredTokens
		{
			get { return 2 + _tokens; }
		}
		
		internal void OccupyBy(Player player, int tokens)
		{
			if (_terrain == null) throw new InvalidOperationException("Cannot occupy the Edge");
			
			// 1. Thrash one token.
			// 2. Return all other tokens to player (TODO: if they are active)
			if (_occupyingPlayer != null) _occupyingPlayer.PickUp(_tokens - 1);
			
			_race = player.Active.Race;
			_occupyingPlayer = player;
			_tokens = tokens;
		}
		
		internal bool OccupiedBy(Player player)
		{
			return _occupyingPlayer == player;
		}

		public bool OccupiedBy(Race race)
		{
			return _race == race;
		}
		
		public void Extinct()
		{
			_occupyingPlayer = null;
			_race = null;
			_tokens = 0;
		}
		
		public int PickUpAllButOne()
		{
			if (_tokens <= 0) throw new InvalidOperationException("Cannot pick up tokens from a non-occupied region");
			int pickUp = _tokens - 1;
			_tokens = 1;
			return pickUp;
		}
		
		internal void ConnectWith(Region rhs)
		{
			this.AddUnique(rhs);
			rhs.AddUnique(this);
		}
		
		private void AddUnique(Region r)
		{
			if (!_adjecent.Contains(r)) _adjecent.Add(r);
		}		
		
		public Terrain TerrainType
		{
			get { return _terrain; }
		}
		
		public IEnumerable<Region> Adjecent
		{
			get { return _adjecent; }
		}
	}
}