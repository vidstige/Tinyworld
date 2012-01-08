using System.Web.Mvc;

namespace Tinyworld
{
	[HandleError]
	public class GameController: Controller
	{
		public ActionResult Show()
		{
			return View();
		}
	}
}