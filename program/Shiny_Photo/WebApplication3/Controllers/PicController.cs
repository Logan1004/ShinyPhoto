using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class PicController : Controller
    {
        // GET: Pic
        public ActionResult PicPage()
        {
            return View();
        }

        public ActionResult PicShopPage()
        {
            return View();
        }
        public ActionResult PicService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrder()
        {
            if (Request.Cookies["loginState"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var userName = Request.Cookies["loginState"].Value;
            if (userName == null)
            {
                return RedirectToAction("Login", "Login");
            }
            Response.Write("<script language=javascript>alert(\"Upload Function Call\")</script>");
            if (Request.Files.Count == 0)
            {
                //Request.Files.Count 文件数为0上传不成功
                Response.Write("<script language=javascript>alert(\"Upload Failed, picture not found\")</script>");
                return View();
            }
            var file = Request.Files[0];
            if (file.ContentLength == 0)
            {
                //文件大小大（以字节为单位）为0时，做一些操作
                Response.Write("<script language=javascript>alert(\"Upload Succeeded without getting the picture\")</script>");
                return View();
            }
            else
            {
                //文件大小不为0
                file = Request.Files[0];
                //保存成自己的文件全路径,newfile就是你上传后保存的文件,
                //服务器上的UpLoadFile文件夹必须有读写权限
                //string target = Server.MapPath("") + "/";//取得目标文件夹的路径
                string target = Server.MapPath("../DownloadedPictures") + ("\\");
                int ifilename = file.GetHashCode();//取得文件哈希
                string filename = Convert.ToString(ifilename, 16);
                string fullFileName = filename + "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                string path = target + fullFileName;
                Response.Write("<script language=javascript>alert(\"Upload Succeed:" + path + "\")</script>");
                file.SaveAs(path);
                ViewData["PicturePath"] = "../DownloadedPictures/" + fullFileName;
                TempData["PictureName"] = filename;
                TempData["PhotoID"] = filename;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Order()
        {
            EntitieFinal entitieFinal = new EntitieFinal();
            string demand = Request["dem"];
            ViewData["demand"] = demand;
            if (Request.Cookies["loginState"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var userName = Request.Cookies["loginState"].Value;
            if (userName==null)
            {
                return RedirectToAction("Login","Login");
            }
            var user = entitieFinal.CUSTOMERs.Single(p => p.CUSTOMER_NAME == userName);

            try
            {
                
                ALL_PHOTO aLL_PHOTO = new ALL_PHOTO();
                aLL_PHOTO.PHOTO_ADDRESS = (string)TempData["PhotoID"];
                aLL_PHOTO.PHOTO_REQUIREMENT = demand;
                aLL_PHOTO.PHOTO_SIZE = 42;
                aLL_PHOTO.PHOTO_STATUS = 0;
                entitieFinal.ALL_PHOTO.Add(aLL_PHOTO);
                entitieFinal.SaveChanges();
                CONTRACT_PHOTO_INFO contract = new CONTRACT_PHOTO_INFO();
                contract.CONTRACT_USER_ID = user.CUSTOMER_ID;
                contract.CONTRACT_PHOTO_ID = entitieFinal.ALL_PHOTO.Single(p=>p.PHOTO_ADDRESS== aLL_PHOTO.PHOTO_ADDRESS).PHOTO_ID;
                contract.CONTRACT_PHOTOREPAIRER_ID = 1;
                contract.CONTRACT_START_DATE = new DateTime();
                contract.CONTRACT_END_DATE = new DateTime();
                contract.CONTRACT_PAYMENT = 80;
                contract.CONTRACT_STATUS = 0;
                entitieFinal.CONTRACT_PHOTO_INFO.Add(contract);
                entitieFinal.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return View();
        }
    }
}