using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using FadakGym.Controllers;
using FadakGym.Helpers;
using FadakGym.ViewModels;
using Microsoft.Ajax.Utilities;

namespace FadakGym.Controllers
{
    public class HomeController : Controller
    {   FadakDbEntities db=new FadakDbEntities();
        public ActionResult Index()
        {
            return View();
        }

        
       

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your login page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user1)
        {
            user1.Password = Cryptography.Encryptor.MD5Hash(user1.Password);
            var checkLogin = db.Users.Where(x => x.Username.Equals(user1.Username) && x.Password.Equals(user1.Password)).FirstOrDefault();
            if (checkLogin != null)
            {
                //Session["ids"] = user1.UserID.ToString();
                
                var us = user1.Username.ToString();
                User obj = db.Users.Where(l => l.Username.Equals(user1.Username)).FirstOrDefault();
                var id=obj.Role.RoleName.ToString();
                Session["role"] = id.ToString();
                string name = obj.Name;
                int idd = obj.UserID;
                Session["usernames"] = name.ToString();
                Session["userid"] = idd.ToString();
                if (id.Equals("Trainee"))
                {
                    return RedirectToAction("UserLogin","Home",(idd));
                }
                else
                {
                    return RedirectToAction("Index", "TraineeRecords");
                }
            }
            else
            {
                ViewBag.Notification = "Wrong username or password";

            }
            return View();
        }


        public ActionResult UserLogin(/*int? idd*/)
        {
            ViewBag.Message = "Here is your info";
            //if (idd.HasValue)
            //{
            //     TraineeRecord trainer = db.TraineeRecords.Find(idd);
            //    return View(trainer);
            //}
            int userid = int.Parse(Session["userid"].ToString());

            db = new FadakDbEntities();
            List< TraineeRecord > tr = new List <TraineeRecord>();
            tr = db.TraineeRecords.Where(s => s.UsedID == userid).ToList();
            return View(tr);
            //return View(db.TraineeRecords.Where(x=>x.User.UserID.Equals(idd)).ToList());

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

    }
}