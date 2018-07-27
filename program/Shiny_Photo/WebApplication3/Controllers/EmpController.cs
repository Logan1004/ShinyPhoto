using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
namespace WebApplication3.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            return RedirectToAction("EmpLogin");
        }
        public ActionResult EmpLogin()
        {
            return View();
        }
        public ActionResult Login()
        {
            if (!string.IsNullOrEmpty(Request["account"]) && !string.IsNullOrEmpty(Request["password"]))
            {
                return RedirectToAction("EmpManage");
            }
            return View("EmpLogin");
        }
        public ActionResult EmpManage()
        {
            EntitieFinal entitie = new EntitieFinal();
            var picList = (from pic in entitie.CONTRACT_PHOTO_INFO
                           select pic).ToList();
            ViewData["PIC"] = picList;

            return View();
        }
    }
}