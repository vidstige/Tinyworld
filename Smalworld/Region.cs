using System;
using System.Collections.Generic;

namespace Smallworld
{
	public class Region
	{
		private readonly Terrain _terrain;
		private readonly IList<Region> _adjecent = new List<Region>();
			
		internal Region(Terrain terrain)
		{
			_terrain = terrain;
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