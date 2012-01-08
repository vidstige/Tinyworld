using System;
using System.Collections.Generic;
using System.Linq;

namespace Tinyworld
{
	public class Polygon
	{
		private IList<Point> _points;
		
		public Polygon(IEnumerable<Point> points)
		{
			_points = points.ToList();
		}
	}
}