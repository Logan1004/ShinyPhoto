using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        Entities entities = new Entities();
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(string id)
        {


            return View();
        }


        public JsonResult TestAjax()
        {
            CUSTOMER c = new CUSTOMER();
            c.CUSTOMER_ID = 1;
            c.CUSTOMER_NAME = "1234";
            c.CUSTOMER_EMAIL = "dbhisv@qq.com";
            return Json(c);
        }

        public ActionResult UserInfo()
        {
            if (Request.Cookies["loginState"].Value == null||!GetUserInfo())
            {
                return RedirectToAction("../Home/Index");
            }
            
            return View();
        }
        [HttpPost]
        public ActionResult ChangePwd()
        {
            if (Request.Cookies["loginState"].Value == null || !GetUserInfo())
            {
                return RedirectToAction("../Home/Index");
            }
            string inputPwd = Request["oldPwd"];
            var userName = Request.Cookies["loginState"].Value;
            EntitieFinal entitie = new EntitieFinal();
            var userList = (from temp in entitie.ALL_LOGIN_INFO
                            where temp.USER_LOGIN_NAME == userName
                            select temp).ToList();
            if (userList.Count() <= 0)
            {
                return RedirectToAction("UserInfo");
            }
            var user = userList.First();
            var userPassword = user.USER_PASSWORD; ;
            if (userPassword != inputPwd)
            {
                ViewData["PWD"] ="密码输入错误";
            }
            else if (string.IsNullOrEmpty(Request["newPwd"]))
            {
                ViewData["EMP"] = "请输入新的密码";
            }
            else if (Request["newPwd"] != Request["confirmPwd"])
            {
                ViewData["NOT"] =  "两次输入密码不一致";
            }
            else
            {
                ViewData["NOT"] = null;
                ViewData["EMP"] = null;
                ViewData["PWD"] = null;
                ALL_LOGIN_INFO loginInfo = entitie.ALL_LOGIN_INFO.Single(p => p.USER_LOGIN_NAME == userName);
                loginInfo.USER_PASSWORD = Request["newPwd"];
                entitie.SaveChanges();
       
            }

            return View("UserInfo");
        }
        public bool GetUserInfo()
        {
            var userName = Request.Cookies["loginState"].Value;
            EntitieFinal entitie = new EntitieFinal();
            var userList = (from temp in entitie.CUSTOMERs
                            where temp.CUSTOMER_NAME == userName
                            select temp).ToList();
            if (userList.Count() <= 0)
            {
                return false;
            }
            var user = userList.First();
            var userID = user.CUSTOMER_ID;
            var equContract = (from temp in entitie.ORDER_EQUIPMENT_INFO
                               where temp.ORDER_USER_ID == userID
                               orderby temp.ORDER_ID ascending
                               select temp).ToList();
            var picContract = (from temp in entitie.CONTRACT_PHOTO_INFO
                               select temp).ToList();
            var userInfo = (from temp in entitie.CUSTOMERs
                            select temp).ToList();
            var address = (from temp in entitie.ALL_ADDRESS
                           where temp.ADDRESS_ID == user.CUSTOMER_ADDRESS_ID
                           select temp).ToList().First();
            string fullAddress = address.COUNTRY + "" + address.CITY + "" + address.DISTRICT + "" + address.DETAIL_ADDRESS;
            ViewData["ORDER"] = equContract;
            ViewData["PICORDER"] = picContract;
            ViewData["ACCOUNT"] = userInfo;
            ViewData["USER"] = userList.First();
            ViewData["ADDRESS"] = fullAddress;
            return true;
        }
        public ActionResult Exit()
        {
            Request.Cookies.Clear();
            Response.Cookies.Clear();
            HttpCookie hc = new HttpCookie("loginState");
            hc.Value = null;
            System.Web.HttpContext.Current.Request.Cookies.Set(hc);
            System.Web.HttpContext.Current.Response.Cookies.Set(hc);
            return RedirectToAction("Index");
        }
	}

}