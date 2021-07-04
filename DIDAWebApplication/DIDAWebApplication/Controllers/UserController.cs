using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DIDAWebApplication.Models;
using DIDAWebApplication.Services;

namespace DIDAWebApplication.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //GET : Creating Page
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //POST : Data Creating
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            //
            User user = new User();
            user.Citize = formCollection["user.Citize"].ToString();
            user.NameSurname = formCollection["user.NameSurname"].ToString();
            user.Telephone = formCollection["user.Telephone"].ToString();
            user.Source = formCollection["addressSource.SubDistrict"].ToString() + ", " 
                          + formCollection["addressSource.District"].ToString() + ", "
                          + formCollection["addressSource.Province"].ToString() + ", "
                          + formCollection["addressSource.Country"].ToString() + ", ";
            user.Destination = formCollection["addressDestination.SubDistrict"].ToString() + ", "
                          + formCollection["addressDestination.District"].ToString() + ", "
                          + formCollection["addressDestination.Province"].ToString() + ", "
                          + formCollection["addressDestination.Country"].ToString() + ", ";

            //insert to db
            UserService userService = new UserService();
            bool result = userService.InsertUser(user);

            if (result)
            {
                return View("Success");
            }
            else
            {
                return View("UnSuccess");
            }
        }

        //GET: List of all users
        [HttpGet]
        public ActionResult Lists()
        {
            return View();
        }
    }
}