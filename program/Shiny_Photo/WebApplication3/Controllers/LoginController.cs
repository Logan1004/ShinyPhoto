using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            Response.Cookies.Clear();
            Request.Cookies.Clear();
            return View();
        }
        [HttpPost]
        public ActionResult Login(ALL_LOGIN_INFO user)
        {
            if (user.USER_LOGIN_NAME == null || user.USER_PASSWORD == null)
            {
                ModelState.AddModelError("LOGIN", "");
            }
            else
            {
                Entities2 entities2 = new Entities2();
                var userExists = (from temp in entities2.ALL_LOGIN_INFO
                                  where temp.USER_LOGIN_NAME == user.USER_LOGIN_NAME
                                  select temp).Count();

                if (userExists > 0)
                {
                    var password = (from temp in entities2.ALL_LOGIN_INFO
                                    where temp.USER_LOGIN_NAME == user.USER_LOGIN_NAME
                                    select temp.USER_PASSWORD).ToList().First();
                    if (password == user.USER_PASSWORD)
                    {
                        Response.Cookies.Clear();
                        Response.Charset = "gb2312";
                        HttpCookie hc = new HttpCookie("loginState");
                        hc.Value = user.USER_LOGIN_NAME;
                        System.Web.HttpContext.Current.Response.Cookies.Add(hc);
                        
                        return this.RedirectToAction("../Home/Index");
                    }
                    else
                    {
                        ModelState.AddModelError("LOGIN", "");
                    }
                }
                else
                {
                    ModelState.AddModelError("LOGIN", "");
                }
            }

            return View();

        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registerppo()
        {
            var name = Request.Form["Item2.USER_LOGIN_NAME"];
            if (string.IsNullOrEmpty(name))
            {
                ModelState.AddModelError("NAME", "用户名不能为空");
            }
            var password = Request.Form["Item2.USER_PASSWORD"];
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("PASSWORD", "密码不能为空");
            }
            var confirm = Request["confirm"];
            if (string.IsNullOrEmpty(confirm))
            {
                ModelState.AddModelError("CONFIRM", "请再次输入密码");
            }
            else if (password != confirm)
            {
                ModelState.AddModelError("PASSWORDCONFIRM", "两次密码不一致");
            }
            var country = Request.Form["Item3.COUNTRY"];
            if (string.IsNullOrEmpty(country))
            {
                ModelState.AddModelError("COUNTRY", "国家不能为空");
            }
            var city = Request.Form["Item3.CITY"];
            if (string.IsNullOrEmpty(city))
            {
                ModelState.AddModelError("CITY", "城市不能为空");
            }
            var district = Request.Form["Item3.DISTRICT"];
            if (string.IsNullOrEmpty(district))
            {
                ModelState.AddModelError("DISTRICT", "区不能为空");
            }
            var address = Request.Form["Item3.DETAIL_ADDRESS"];
            if (string.IsNullOrEmpty(address))
            {
                ModelState.AddModelError("ADDRESS", "地址不能为空");
            }
            var email = Request.Form["Item4.CUSTOMER_EMAIL"];
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("EMAIL", "邮箱不能为空");
            }
            var tel = Request.Form["Item1.USER_TEL"];
            if (string.IsNullOrEmpty(tel))
            {
                ModelState.AddModelError("TEL", "手机电话不能为空");
            }

            if (ModelState.IsValid)
            {
                //name password country city district address email tel
                Entities2 entities = new Entities2();
                ALL_ADDRESS addressInsert = new ALL_ADDRESS();
                addressInsert.COUNTRY = country;
                addressInsert.CITY = city;
                addressInsert.DISTRICT = district;
                addressInsert.DETAIL_ADDRESS = address;
                addressInsert.ZIPCODE = 100000;
                Test1 test1 = new Test1();

                test1.ALL_ADDRESS.Add(addressInsert);
                test1.SaveChanges();
                var m = from a in entities.ALL_ADDRESS where a.COUNTRY == country & a.CITY == city & a.DISTRICT == district & a.DETAIL_ADDRESS == address select a.ADDRESS_ID;

                CUSTOMER customer = new CUSTOMER();
                customer.CUSTOMER_NAME = name;
                customer.CUSTOMER_ADDRESS_ID = m.ToList().First();
                customer.CUSTOMER_EMAIL = email;
                customer.CUSTOMER_IS_ASSOCIATE = 1;
                customer.CUSTOMER_SEX = 0;
                test1.CUSTOMERs.Add(customer);
                test1.SaveChanges();

                var m1 = from a in entities.CUSTOMERs where a.CUSTOMER_NAME == name & a.CUSTOMER_EMAIL == email select a.CUSTOMER_ID;
                ALL_USER_TEL telphone = new ALL_USER_TEL();
                telphone.USER_ID = m1.ToList().First();
                telphone.USER_TEL = long.Parse(tel);
                test1.ALL_USER_TEL.Add(telphone);
                test1.SaveChanges();

                ALL_LOGIN_INFO login_info = new ALL_LOGIN_INFO();
                login_info.USER_ID = m1.ToList().First();
                login_info.USER_LOGIN_NAME = name;
                login_info.USER_PASSWORD = password;
                login_info.USER_STATUS = 0;
                test1.ALL_LOGIN_INFO.Add(login_info);
                test1.SaveChanges();

                return this.RedirectToAction("../Home/Index");
            }

            return View("Register");
        }
    }
}