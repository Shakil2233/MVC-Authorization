using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using FinalEve.Models;

namespace FinalEve.Controllers
{
    public class AccessController : Controller
    {
       

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.UserInfo model)
        {
            using (var context = new ApplicationContext())
            {
                bool isValid = context.Logins.Any(x => x.Name == model.Name && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, false);
                    return RedirectToAction("OrderInfo", "Order");
                }
                ModelState.AddModelError("", "Invalid Login");
                return View();
            }

        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Models.Login model)
        {
            using (var context = new ApplicationContext())
            {
                context.Logins.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}