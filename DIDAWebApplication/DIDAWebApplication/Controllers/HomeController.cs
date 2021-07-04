using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DIDAWebApplication.Services;

namespace DIDAWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UserService user = new UserService();
            ViewBag.Province = user.GetUserFromProvince("Bangkok");
            ViewBag.Aboard = user.GetUserFromAboard();
            return View();
        }
    }
}