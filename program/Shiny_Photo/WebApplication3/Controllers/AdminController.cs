using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            GetData();
            return RedirectToAction("AdminLogin");
        }
        public ActionResult AdminLogin()
        {
            GetData();
            return View();
        }
        [HttpPost]
        public ActionResult Login()
        {
            GetData();
            if (!string.IsNullOrEmpty(Request["account"])&& Request["account"] == "Admin")
            {
                return RedirectToAction("AdminView");
            }
            return View("AdminLogin");
        }
        public ActionResult AdminView()
        {
            GetData();
            ViewData["equEdit"] = null;
            ViewData["picEdit"] = null;
            ViewData["userEdit"] = null;
            ViewData["empEdit"] = null;

            return View();
        }


        [HttpPost]
        public ActionResult EquDelete(string orderID)
        {
            ViewData["front"] = "1";
            var ID = long.Parse(orderID);
            EntitieFinal entitie = new EntitieFinal();
            var order = entitie.ORDER_EQUIPMENT_INFO.Single(temp => temp.ORDER_ID == ID);
            entitie.ORDER_EQUIPMENT_INFO.Remove(order);
            entitie.SaveChanges();
            GetData();
            return RedirectToAction("AdminView");
        }
        [HttpPost]
        public ActionResult EquAddOrSearch(string op)
        {
            ViewData["front"] = "1";
            EntitieFinal entitie = new EntitieFinal();
            if (op =="add")
            {
                var order = new ORDER_EQUIPMENT_INFO();
                order.ORDER_USER_ID = long.Parse(Request["USER"]);
                order.ORDER_EQUIPMENT_ID = long.Parse(Request["EQUID"]);
                order.ORDER_START_DATE = Convert.ToDateTime(Request["START"]);
                order.ORDER_END_DATE = Convert.ToDateTime(Request["END"]);
                order.ORDER_PAYMENT = Convert.ToDecimal(Request["PAY"]);
                order.ORDER_ADDRESS_DETAIL = "嘉定";
                order.ORDER_STATUS = 1;
                entitie.ORDER_EQUIPMENT_INFO.Add(order);
                entitie.SaveChanges();
                GetData();
                return RedirectToAction("AdminView");
            }
            else
            {
                var orderList = from order in entitie.ORDER_EQUIPMENT_INFO
                                select order;
                if (!string.IsNullOrEmpty(Request["ORDERID"]))
                {
                    var p = long.Parse(Request["ORDERID"]);
                    orderList = from order in orderList
                                where order.ORDER_ID == p
                                select order;
                }
                if (!string.IsNullOrEmpty(Request["USER"]))
                {
                    var p = long.Parse(Request["USER"]);
                    orderList = from order in orderList
                                where order.ORDER_USER_ID == p
                                select order;
                }
                if (!string.IsNullOrEmpty(Request["EQUID"]))
                {
                    var p = long.Parse(Request["EQUID"]);
                    orderList = from order in orderList
                                where order.ORDER_EQUIPMENT_ID == p
                                select order;
                }
                if (!string.IsNullOrEmpty(Request["START"]))
                {
                    var p = Convert.ToDateTime(Request["START"]);
                    orderList = from order in orderList
                                where order.ORDER_START_DATE == p
                                select order;
                }
                if (!string.IsNullOrEmpty(Request["END"]))
                {
                    var p = Convert.ToDateTime(Request["END"]);
                    orderList = from order in orderList
                                where order.ORDER_END_DATE == p
                                select order;
                }
               if (!string.IsNullOrEmpty(Request["PAY"]))
                {
                    var p = Convert.ToDecimal(Request["PAY"]);
                    orderList = from order in orderList
                                where order.ORDER_PAYMENT == p
                                select order;
                }
                GetData();
                ViewData["EQU"] = orderList.ToList();
            }
            

            return View("AdminView");
            
        }




        [HttpPost]
        public ActionResult PicDelete(string picID)
        {
            ViewData["front"] = "2";
            var ID = long.Parse(picID);
            EntitieFinal entitie = new EntitieFinal();
            var pic = entitie.CONTRACT_PHOTO_INFO.Single(temp => temp.CONTRACT_PHOTO_ID == ID);
            entitie.CONTRACT_PHOTO_INFO.Remove(pic);
            entitie.SaveChanges();
            GetData();
            return RedirectToAction("AdminView");
        }
        [HttpPost]
        public ActionResult PicAddOrSearch(string op)
        {
            ViewData["front"] = "2";
            EntitieFinal entitie = new EntitieFinal();
            if (op == "add")
            {
                var pic = new CONTRACT_PHOTO_INFO();
                pic.CONTRACT_PHOTO_ID = long.Parse(Request["PICID"]);
                pic.CONTRACT_USER_ID = long.Parse(Request["USER"]);
                pic.CONTRACT_PHOTOREPAIRER_ID = long.Parse(Request["REP"]);
                pic.CONTRACT_START_DATE = Convert.ToDateTime(Request["START"]);
                pic.CONTRACT_END_DATE = Convert.ToDateTime(Request["END"]);
                pic.CONTRACT_PAYMENT = long.Parse(Request["PAY"]);
                pic.CONTRACT_STATUS = 0;
                entitie.CONTRACT_PHOTO_INFO.Add(pic);
                entitie.SaveChanges();
                GetData();
                return RedirectToAction("AdminView");
            }
            else
            {
                var picList = from pic in entitie.CONTRACT_PHOTO_INFO
                                select pic;
                if (!string.IsNullOrEmpty(Request["PICID"]))
                {
                    var p = long.Parse(Request["PICID"]);
                    picList = from pic in picList
                              where pic.CONTRACT_PHOTO_ID == p
                                select pic;
                }
                if (!string.IsNullOrEmpty(Request["USER"]))
                {
                    var p = long.Parse(Request["USER"]);
                    picList = from pic in picList
                              where pic.CONTRACT_USER_ID == p
                                select pic;
                }
                if (!string.IsNullOrEmpty(Request["REP"]))
                {
                    var p = long.Parse(Request["REP"]);
                    picList = from pic in picList
                              where pic.CONTRACT_PHOTOREPAIRER_ID == p
                                select pic;
                }
                if (!string.IsNullOrEmpty(Request["START"]))
                {
                    var p = Convert.ToDateTime(Request["START"]);
                    picList = from pic in picList
                              where pic.CONTRACT_START_DATE == p
                                select pic;
                }
                if (!string.IsNullOrEmpty(Request["END"]))
                {
                    var p = Convert.ToDateTime(Request["END"]);
                    picList = from pic in picList
                              where pic.CONTRACT_END_DATE == p
                                select pic;
                }
                if (!string.IsNullOrEmpty(Request["PAY"]))
                {
                    var p = Convert.ToDecimal(Request["PAY"]);
                    picList = from order in picList
                                where order.CONTRACT_PAYMENT == p
                                select order;
                }
                GetData();
                ViewData["PIC"] = picList.ToList();
            }


            return View("AdminView");
        }



        [HttpPost]
        public ActionResult EmpDelete(string empID)
        {
            ViewData["front"] = "3";
            var ID = long.Parse(empID);
            EntitieFinal entitie = new EntitieFinal();
            var emp = entitie.EMPLOYEEs.Single(temp => temp.EMPLOYEE_ID == ID);
            entitie.EMPLOYEEs.Remove(emp);
            entitie.SaveChanges();
            GetData();
            return RedirectToAction("AdminView");
        }
        [HttpPost]
        public ActionResult EmpAddOrSearch(string op)
        {
            ViewData["front"] = "3";
            EntitieFinal entitie = new EntitieFinal();
            if (op == "add")
            {
                var emp = new EMPLOYEE();
                emp.EMPLOYEE_ID = long.Parse(Request["ID"]);
                emp.EMPLOYEE_NAME = Request["NAME"];
                emp.EMPLOYEE_SEX = 0;
                if (Request["NAME"]=="女")
                {
                    emp.EMPLOYEE_SEX = 1;
                }
                emp.EMPLOYEE_EMAIL = Request["EMAIL"];
                emp.EMPLOYEE_DEPART_NAME = Request["DEP"];
                emp.EMPLOYEE_TITLE = Request["TIT"];
                emp.EMPLOYEE_SALARY = 0;
                emp.EMPLOYEE_ADDRESS_ID = 1;
                emp.EMPLOYEE_ENTRY_TIME = new DateTime(2000, 1, 1);
                entitie.EMPLOYEEs.Add(emp);
                entitie.SaveChanges();
                GetData();
                return RedirectToAction("AdminView");
            }
            else
            {
                var empList = from emp in entitie.EMPLOYEEs
                                select emp;
                if (!string.IsNullOrEmpty(Request["ID"]))
                {
                    var p = long.Parse(Request["ID"]);
                    empList = from emp in empList
                              where emp.EMPLOYEE_ID == p
                                select emp;
                }
                if (!string.IsNullOrEmpty(Request["NAME"]))
                {
                    var p = Request["NAME"];
                    
                    empList = from emp in empList
                              where emp.EMPLOYEE_NAME == p
                                select emp;
                }
                if (!string.IsNullOrEmpty(Request["SEX"]))
                {
                    long p = 0;
                    if (Request["SEX"]=="女")
                    {
                        p = 1;
                    }
                    empList = from emp in empList
                              where emp.EMPLOYEE_SEX == p
                                select emp;
                }
                if (!string.IsNullOrEmpty(Request["EMAIL"]))
                {
                    var p = Request["EMAIL"];
                    empList = from emp in empList
                              where emp.EMPLOYEE_EMAIL == p
                                select emp;
                }
                if (!string.IsNullOrEmpty(Request["DEP"]))
                {
                    var p = Request["DEP"];
                    empList = from emp in empList
                              where emp.EMPLOYEE_DEPART_NAME == p
                                select emp;
                }
                if (!string.IsNullOrEmpty(Request["TIT"]))
                {
                    var p = Request["TIT"];
                    empList = from emp in empList
                              where emp.EMPLOYEE_TITLE == p
                                select emp;
                }
                GetData();
                ViewData["EMP"] = empList.ToList();
            }


            return View("AdminView");
        }




        [HttpPost]
        public ActionResult UserDelete(string userID)
        {
            ViewData["front"] = "4";
            var ID = long.Parse(userID);
            EntitieFinal entitie = new EntitieFinal();
            var user = entitie.CUSTOMERs.Single(temp => temp.CUSTOMER_ID == ID);
            entitie.CUSTOMERs.Remove(user);
            entitie.SaveChanges();
            GetData();
            return RedirectToAction("AdminView");
        }
        [HttpPost]
        public ActionResult UserAddOrSearch(string op)
        {

            ViewData["front"] = "4";
            EntitieFinal entitie = new EntitieFinal();
            if (op == "add")
            {
                var user = new CUSTOMER();
                user.CUSTOMER_ID = long.Parse(Request["ID"]);
                user.CUSTOMER_NAME = Request["NAME"];
                user.CUSTOMER_SEX = 0;
                if (Request["SEX"] == "女")
                {
                    user.CUSTOMER_SEX = 1;
                }
                user.CUSTOMER_ADDRESS_ID = Int32.Parse(Request["ADDRESS"]);
                user.CUSTOMER_EMAIL = Request["EMAIL"];
                user.CUSTOMER_IS_ASSOCIATE = 1;
                entitie.CUSTOMERs.Add(user);
                entitie.SaveChanges();
                GetData();
                return RedirectToAction("AdminView");
            }
            else
            {
                var userList = from user in entitie.CUSTOMERs
                              select user;
                if (!string.IsNullOrEmpty(Request["ID"]))
                {
                    var p = long.Parse(Request["ID"]);
                    userList = from user in userList
                              where user.CUSTOMER_ID == p
                              select user;
                }
                if (!string.IsNullOrEmpty(Request["NAME"]))
                {
                    var p = Request["NAME"];

                    userList = from user in userList
                               where user.CUSTOMER_NAME == p
                              select user;
                }
                if (!string.IsNullOrEmpty(Request["SEX"]))
                {
                    long p = 0;
                    if (Request["SEX"] == "女")
                    {
                        p = 1;
                    }
                    userList = from user in userList
                              where user.CUSTOMER_SEX == p
                              select user;
                }
                if (!string.IsNullOrEmpty(Request["ADDRESS"]))
                {
                    var p = long.Parse(Request["ADDRESS"]);
                    userList = from user in userList
                               where user.CUSTOMER_ADDRESS_ID == p
                              select user;
                }
                if (!string.IsNullOrEmpty(Request["EMAIL"]))
                {
                    var p = Request["DEP"];
                    userList = from user in userList
                               where user.CUSTOMER_EMAIL == p
                              select user;
                }
                GetData();
                ViewData["USER"] = userList.ToList();
            }


            return View("AdminView");
        }







        public void GetData()
        {
            EntitieFinal entitie = new EntitieFinal();
            var equList = (from equ in entitie.ORDER_EQUIPMENT_INFO
                          select equ).ToList();
            ViewData["EQU"] = equList;
            var picList = (from pic in entitie.CONTRACT_PHOTO_INFO
                          select pic).ToList();
            ViewData["PIC"] = picList;
            var userList = (from user in entitie.CUSTOMERs
                          select user).ToList();
            ViewData["USER"] = userList;
            var empList = (from emp in entitie.EMPLOYEEs
                          select emp).ToList();
            ViewData["EMP"] = empList;
        }
    }
}