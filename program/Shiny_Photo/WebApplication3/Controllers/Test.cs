using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Controllers
{
	public class TestController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Upload()
		{
			HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
			string imgPath = "";
			if (hfc.Count > 0)
			{
				imgPath = "/testUpload" + hfc[0].FileName;
				string PhysicalPath = Server.MapPath(imgPath);
				hfc[0].SaveAs(PhysicalPath);
			}
			return Content(imgPath);
		}
	}
}