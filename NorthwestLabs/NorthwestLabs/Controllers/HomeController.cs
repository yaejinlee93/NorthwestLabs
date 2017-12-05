using NorthwestLabs.DAL;
using NorthwestLabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NorthwestLabs.Controllers
{
    public class HomeController : Controller
    {
        private NWLMasterContext db = new NWLMasterContext();

        public ActionResult Index()
        {
            return View();
        }

        //GET: Home
        public ActionResult Login()
        {
            ViewBag.errorMessage = "";
            return View();
        }

        //POST: Home
        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String username = form["Username"].ToString();
            String password = form["Password"].ToString();

            var oUser = db.Database.SqlQuery<User>
            ("SELECT * FROM [Web_User] WHERE userName COLLATE Latin1_General_CS_AS = '" + username + "' AND " +
            "userPassword COLLATE Latin1_General_CS_AS = '" + password + "'").SingleOrDefault();

            if (oUser != null)
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);

                TempData["myObject"] = oUser;
                TempData["userID"] = oUser.userID;

                return RedirectToAction("EmployeePage", "User");
            }
            else
            {
                //error message or reduce login count
                ViewBag.errorMessage = "INVALID USERNAME OR PASSWORD";
            }


            if (string.Equals(username, "Missouri") && (string.Equals(password, "ShowMe")))
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);

                return RedirectToAction("UpdateData", "Manage");

            }
            else
            {
                ViewBag.errorMessage = "INCORRECT USERNAME/PASSWORD.";
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}