﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2.Models.Entity;
using Mooshak2.Services;

namespace Mooshak2.Controllers
{
    public class AdminController : Controller
    {
        UserService uS = new UserService();
        CourseService cS = new CourseService();

        public ActionResult CreateCourse()
        {
            

            List<Teacher> ListOfAllTeachers = new List<Teacher>();
            ListOfAllTeachers = uS.GetAllTeachers();

            return View(ListOfAllTeachers);
        }

        [HttpPost]
        public ActionResult CreateCourse(FormCollection formCollection)
        {
       
            string courseName = Request.Form["coursename"];
            string courseTeacher = Request.Form["teacher"];

            
            cS.CreateCourse(courseName, courseTeacher);

            return View("~/Views/Teacher/HomePage.cshtml"); 
        }



        public ActionResult CreateUser()
        {
            List<Course> listOfAllCourses = new List<Course>();
            listOfAllCourses = cS.GetAllCourses();

            return View(listOfAllCourses);
        }

        [HttpPost]
        public ActionResult CreateUser(FormCollection formCollection)
        {

            string name = Request.Form["name"];
            string userName = Request.Form["username"];
            string ssn = Request.Form["ssn"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string userRole = Request.Form["role"];
            string course = Request.Form["course"];

            UserService uS = new UserService();

            uS.CreateUser(name, userName, ssn, email, password, userRole, course);

            return RedirectToAction("~/Views/Teacher/HomePage.cshtml");
        }



        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult ViewCourse()
        {
            return View();
        }

        public ActionResult ViewUsers()
        {
            return View();
        }

    }
}