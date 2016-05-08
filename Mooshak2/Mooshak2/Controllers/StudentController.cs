using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2.Services;
using Mooshak2.Models;
using Mooshak2.Models.Entity;

namespace Mooshak2.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult HomePage()
        {

            
      
            return View();

        }

        public ActionResult ViewAssignments()
        {

            List<Student> listOfStudents = new List<Student>();
            UserService us = new UserService();
            //listOfStudents = us.GetAllStudents();


            return View(listOfStudents);
        }

    }
}