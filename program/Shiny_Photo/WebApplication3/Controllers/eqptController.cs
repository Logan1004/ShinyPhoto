using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class eqptController : Controller
    {
        // GET: eqpt
        public ActionResult Eqpt()
        {
            return View();
        }

        public ActionResult EqptPage(string typeIndex)
        {
            EntitieFinal entitie = new EntitieFinal();
            var equList = (from temp in entitie.EQUIPMENT_INFO
                           select temp).ToList();
            var cam = (from temp in entitie.EQUIPMENT_INFO
                     where temp.EQUIPMENT_CATEGORY == "摄像机"
                     orderby temp.EQUIPMENT_ID ascending
                     select temp).ToList();
            ViewData["CAM"] = cam;
            var dir = (from temp in entitie.EQUIPMENT_INFO
                       where temp.EQUIPMENT_CATEGORY == "单反相机"
                       orderby temp.EQUIPMENT_ID ascending
                       select temp).ToList();
            ViewData["DIR"] = dir;
            var head = (from temp in entitie.EQUIPMENT_INFO
                       where temp.EQUIPMENT_CATEGORY == "镜头"
                       orderby temp.EQUIPMENT_ID ascending
                       select temp).ToList();
            ViewData["HEAD"] = head;
            var fly = (from temp in entitie.EQUIPMENT_INFO
                        where temp.EQUIPMENT_CATEGORY == "航拍飞机"
                        orderby temp.EQUIPMENT_ID ascending
                        select temp).ToList();
            ViewData["FLY"] = fly;
            var tri = (from temp in entitie.EQUIPMENT_INFO
                        where temp.EQUIPMENT_CATEGORY == "三脚架"
                        orderby temp.EQUIPMENT_ID ascending
                        select temp).ToList();
            ViewData["TRI"] = tri;
            var pai = (from temp in entitie.EQUIPMENT_INFO
                        where temp.EQUIPMENT_CATEGORY == "拍立得"
                        orderby temp.EQUIPMENT_ID ascending
                        select temp).ToList();
            ViewData["PAI"] = pai;
            var other = (from temp in entitie.EQUIPMENT_INFO
                       where temp.EQUIPMENT_CATEGORY == "其他"
                       orderby temp.EQUIPMENT_ID ascending
                       select temp).ToList();
            ViewData["OTHER"] = other;
            return View();
        }


        public ActionResult EqptBuyPage(string equID)
        {
            
            TempData["curData"] = equID;
            ViewData["EQTID"] = equID;
            int ID = Convert.ToInt32(equID);
            EntitieFinal entitie = new EntitieFinal();
            var equList = (from temp in entitie.EQUIPMENT_INFO
                       where temp.EQUIPMENT_ID == (long)ID
                       select temp).ToList();
            if (equList.Count()>0)
            {
                var equ = equList.First();
                ViewData["DETAIL"] = equ.EQUIPMENT_DETAIL;
                ViewData["RENT"] = equ.EQUIPMENT_RENT;
            }
            return View();
        }
        [HttpPost]
        public ActionResult EqptBuy()
        {
            if (Request.Cookies["loginState"] == null)
            {
                return RedirectToAction("../Login/Login");
            }

            EntitieFinal entitieFinal = new EntitieFinal();
            var address = Request.Form["Item1.ORDER_ADDRESS_DETAIL"];
            var startDate = Request.Form["Item1.ORDER_START_DATE"];
            var endDate = Request.Form["Item1.ORDER_END_DATE"];
            int id = Int32.Parse(TempData["curData"].ToString());
            if (address == "" || startDate == "" || endDate == "")
            {
                Response.Write("<script>alert('订单错误！')</script>");
                var s = id.ToString();
                return RedirectToAction("EqptBuyPage", new { equID = s });
            }
            ORDER_EQUIPMENT_INFO order = new ORDER_EQUIPMENT_INFO();
            order.ORDER_ADDRESS_DETAIL = address;
            order.ORDER_END_DATE = Convert.ToDateTime(endDate);
            order.ORDER_START_DATE = Convert.ToDateTime(startDate);

            string name = Request.Cookies["loginState"].Value;
            order.ORDER_EQUIPMENT_ID = id;
            order.ORDER_STATUS = 1;
            var user_id = (from temp in entitieFinal.CUSTOMERs
                           where temp.CUSTOMER_NAME == name
                           select temp.CUSTOMER_ID).ToList().First();
            order.ORDER_USER_ID = user_id;

            var payment = (from temp in entitieFinal.EQUIPMENT_INFO
                           where temp.EQUIPMENT_ID == id
                           select temp.EQUIPMENT_RENT).ToList().First();
            order.ORDER_PAYMENT = payment;
            entitieFinal.ORDER_EQUIPMENT_INFO.Add(order);
            entitieFinal.SaveChanges();
            Response.Write("<script>alert('购买成功')</script>");
            return View("../Home/Index");
        }

        public ActionResult EquRent()
        {
            return View("");
        }
    }
}