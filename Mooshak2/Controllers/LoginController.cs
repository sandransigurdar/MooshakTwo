using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2.Models;
using Mooshak2.Services;

namespace Mooshak2.Controllers
{
    public class LoginController : Controller
    {
        UserService us = new UserService();
        LoginService ls = new LoginService();

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            string name = Request.Form["username"];
            string password = Request.Form["password"];

           
            int userRole;

            userRole = ls.Authenticate(name, password);
            //int userRole = 1;

            if (userRole==1)
            {
                
                var student = us.getStudentByName(name);
                LoginService.nameOfLoggedInUser = name;
                return View("~/Views/Student/HomePage.cshtml" , student);
            }

            else if (userRole==2)
            {
                LoginService.nameOfLoggedInUser = name;
                return View("~/Views/Teacher/HomePage.cshtml");
            }

            else if (userRole==3)
            {
                LoginService.nameOfLoggedInUser = name;
                return View("~/Views/Admin/HomePage.cshtml");
            }

            else
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
        }
    }
}
