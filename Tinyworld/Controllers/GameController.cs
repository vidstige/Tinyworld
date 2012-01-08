using System.Web.Mvc;
using System.Collections.Generic;

namespace Tinyworld
{
	[HandleError]
	public class GameController: Controller
	{
		public ActionResult Show()
		{
			var list = new List<PolygonRegion>();
			list.Add(new PolygonRegion(null, null));
			list.Add(new PolygonRegion(null, null));
			list.Add(new PolygonRegion(null, null));
			return View(new Board(list));
		}
	}
}