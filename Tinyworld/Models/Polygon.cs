using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tinyworld
{
	public class Polygon
	{
		private IList<Point> _points;
		
		public Polygon(IEnumerable<Point> points)
		{
			_points = points.ToList();
		}
		
		public static Polygon FromHtmlString(string html)
		{
			var values = html.Split(",".ToCharArray());
			var points = new List<Point>();
			for (int i=0; i < values.Length; i += 2)
			{
				points.Add(new Point(int.Parse(values[i]), int.Parse(values[i+1])));
			}
			return new Polygon(points);
		}
		
		public string GetHtmlCoordinates()
		{
			return string.Join(", ", _points.Select(p => string.Format("{0}, {1}", p.X, p.Y)).ToArray());
		}
	}
}