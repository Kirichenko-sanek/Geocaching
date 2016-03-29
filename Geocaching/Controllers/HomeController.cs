using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Geocaching.Core;
using Geocaching.Filters;
using Geocaching.Interfases.Manager;

namespace Geocaching.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        private readonly IUserManager<User> _managerUser;

        public HomeController(IUserManager<User> managerUser)
        {
            _managerUser = managerUser;
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false) return View();
            var user = _managerUser.GetUserByEmail(User.Identity.Name);
            if (user != null)
            {
                Session["UserId"] = user.id;
            }           
            return View();
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

        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.ToString();
            List<string> cultures = new List<string>() { "en", "ru" };
            if (!cultures.Contains(lang))
            {
                lang = "en";
            }
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;
            else
            {
                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
    }
}