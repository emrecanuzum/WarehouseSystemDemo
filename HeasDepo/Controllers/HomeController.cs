using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using HeasDepo.Models;
using Microsoft.Ajax.Utilities;
using Bytescout.BarCodeReader;

namespace HeasDepo.Controllers
{
    public class HomeController : Controller
    {
        heas_depoEntities db = new heas_depoEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginProcess(HeasDepo.Models.Login users)
        {
            using (heas_depoEntities db = new heas_depoEntities())
            {


                MD5 md5 = new MD5CryptoServiceProvider();

                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(users.Password));

                byte[] result = md5.Hash;

                StringBuilder strBuilder = new StringBuilder();

                for (int i = 0; i < result.Length; i++)
                {
                    strBuilder.Append(result[i].ToString("x2"));
                }

                string pass = strBuilder.ToString();
                
                if (!this.IsCaptchaValid(errorText: ""))
                {
                    //ViewBag.ErrorMessge = "Captcha is not valid";
                    return View("Index", users);
                }
               
                var userDetails = db.Login.Where(x => x.Email == users.Email && x.Password == pass).FirstOrDefault();
                if (userDetails == null)
                {
                  //  designers.LoginErrorMessage = "Wrong Input.";
                    return View("Index", users);
                }

                else
                {
                    Session["userName"] = userDetails.Name;
                    Session["userSurname"] = userDetails.Surname;
                    Session["userEmail"] = userDetails.Email;
                    Session["userTitle"] = userDetails.Title;

                    return RedirectToAction("List");
                }


                
            }
        }

        public ActionResult List(string p)
        {
            var y = from d in db.MainView select d;
            if (!string.IsNullOrEmpty(p))
            {
                y = y.Where(m => m.dCategory.Contains(p));
            }
            return View(y.ToList());
        }

        
        [HttpGet]
        public ActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewUser(Login u1)
        {

            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(u1.Password));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            string pass = strBuilder.ToString();

            u1.Password = pass;
            db.Login.Add(u1);
            db.SaveChanges();
            return RedirectToAction("List");
        }



        


        [HttpGet]
        public ActionResult NewProduct()
        {
            var items = db.CategoryTable.ToList();
            if (items != null)
            {
                ViewBag.data = items;
            }

            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(WarehouseTbl p1)
        {
            db.WarehouseTbl.Add(p1);
            db.SaveChanges();
            return RedirectToAction("List");
        }




        [HttpGet]
        public ActionResult UpdateProduct(string id)
        {
            // var ProductRec = (from item in db.Warehouse
            //                  where item.dSN == a
            //                select item).First(); 
            var items = db.CategoryTable.ToList();
            if (items != null)
            {
                ViewBag.data = items;
            }

            var x = db.WarehouseTbl.Find(id);
            return View("UpdateProduct", x);
        }



        public ActionResult UpdateProductProcess(WarehouseTbl p1)
        {
            var y = db.WarehouseTbl.Find(p1.dSN);
            y.dCategoryID = p1.dCategoryID;
            y.dInfo = p1.dInfo;
            y.dSN = p1.dSN;
            y.dHEASID = p1.dHEASID;
            y.dDescription = p1.dDescription;

            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Deleted(string p)
        {
            var y = from d in db.DeletedView select d;
            if (!string.IsNullOrEmpty(p))
            {
                y = y.Where(m => m.dCategory.Contains(p));
            }
            return View(y.ToList());
        }


        [HttpGet]
        public ActionResult DeleteProduct(string id)
        {
            var x = db.WarehouseTbl.Find(id);
           // db.WarehouseTbl.Remove(x);
           // db.SaveChanges();
            return View("DeleteProduct", x);
        }

        public ActionResult Deletion(WarehouseTbl d1, string dReason, string dMethod)
        {
            var y = db.DeleteProcess.Create();

            y.dCategoryID = d1.dCategoryID;
            y.dProductInfo = d1.dInfo;
            y.dSNum = d1.dSN;
            y.dReason = dReason;
            y.dMethod = dMethod;
            y.dDate = DateTime.Now;
            y.dName = Session["userName"].ToString();
            y.dSurname = Session["userSurname"].ToString();

            

            var x = db.WarehouseTbl.Find(d1.dSN);
             db.WarehouseTbl.Remove(x);
            // db.SaveChanges();
            db.DeleteProcess.Add(y);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult BarCodeRead()
        {
            return View();
        }
     

        //md5 ile şifreyi al
        //captcha

    }


}