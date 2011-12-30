using System;
using System.Linq;
using System.Collections.Generic;

namespace Smallworld
{
	public static class Regions
	{
		public static IEnumerable<Region> AdjecentTo(IEnumerable<Region> regions)
		{
			var result = new List<Region>();
			foreach (var region in regions.SelectMany(r => r.Adjecent))
			{
				if (!result.Contains(region) && !regions.Contains(region)) result.Add(region);
			}
			return result;
		}
	}
}