using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
	public class TestController : Controller
	{
		// GET: Test
		public ActionResult Index()
		{
			return View("Upload");
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

		public ActionResult Update()
		{
			Entities2 entities2 = new Entities2();
			//_list = _list.OrderBy(c => c.ID).Skip(int.Parse(LastPageSize)).Take(PageSize).ToList();
			//var m = (from temp in entities.AAAs where temp.ID == a.ID select temp).
			List<CUSTOMER> list = entities2.CUSTOMERs.ToList();
			return View(list);
		}

	}
}