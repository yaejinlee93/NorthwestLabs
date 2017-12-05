using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthwestLabs.Models;
using NorthwestLabs.DAL;

namespace NorthwestLabs.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private NWLMasterContext db = new NWLMasterContext();

        // GET: User
        public ActionResult ClientPage()
        {
            return View();
        }

        public ActionResult EmployeePage()
        {
            //Redirect if not an employee
            int usernumber = (int)TempData["userID"];
            var oUser = db.Database.SqlQuery<User>("SELECT * from userAccounts WHERE userID = " + usernumber + ";").First();
            //string userType = db.Database.SqlQuery<User>("SELECT userType from Web_User WHERE userID = " + usernumber + ";").First().ToString();
            string userType = oUser.userType;

            if(userType == "employee")
            {
                return View();
            }
            else
            {
                return RedirectToAction("ClientPage");
            }
        }
    }
}