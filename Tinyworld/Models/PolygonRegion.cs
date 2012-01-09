using System;
using Smallworld;

namespace Tinyworld
{
	public class PolygonRegion
	{
		private Region _region;
		private Polygon _polygon;
		
		public PolygonRegion(Region region, Polygon polygon)
		{
			_region = region;
			_polygon = polygon;
		}
		
		public string HtmlCoordinates()
		{
			return _polygon.GetHtmlCoordinates();
		}
	}
}