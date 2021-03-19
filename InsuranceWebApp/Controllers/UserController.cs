using InsuranceWebApp.DAL;
using InsuranceWebApp.Filter;
using InsuranceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceWebApp.Controllers
{
    public class UserController : Controller
    {
        // GET: 
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAuth loginUser)
        {
            using (UserRepository ur = new UserRepository())
            {
                UserAuth user = ur.AuthenticateUser(loginUser.UserName, loginUser.Password);
                if(user == null)
                {
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    Session["LoggedUserName"] = user.UserName;
                    Session["Role"] = user.Role;
                    return RedirectToAction("DivertToAdminPage", "User");
                }
            }
        }

        public ActionResult Unauthorize()
        {
            return View();
        }

        [UnAuthorizedFilter]
        public ActionResult DivertToAdminPage()
        {
            return RedirectToAction("Policies", "Insurance");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Remove("Role");
            if (Request.Cookies["ASP.NET_SessionId"].Value != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = String.Empty;
            }
            return View("Login");
        }
    }
}