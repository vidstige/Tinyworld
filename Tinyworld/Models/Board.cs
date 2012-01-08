using System;
using System.Collections.Generic;

namespace Tinyworld
{
	public class Board
	{
		private IList<PolygonRegion> _regions;
		
		public Board(IList<PolygonRegion> regions)
		{
			_regions = regions;
		}
		
		public IEnumerable<PolygonRegion> Regions
		{
			get { return _regions; }
		}
	}
}