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
		
		public static Region Edge = new Region(null);
		
		internal Region(Terrain terrain)
		{
			_terrain = terrain;
		}
		
		public int RequiredTokens
		{
			get { return 2 + _tokens; }
		}
		
		public void OccupyBy(Race race, int tokens)
		{
			if (_terrain == null) throw new InvalidOperationException("Cannot occupy the Edge");
			_race = race;
			// TODO: Return one token to the owning player, move one token to thrash
			_tokens = tokens;
		}
		
		public bool OccupiedBy(Race race)
		{
			return _race == race;
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