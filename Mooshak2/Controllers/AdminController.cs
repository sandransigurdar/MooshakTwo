using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2.Models.Entity;
using Mooshak2.Services;
using Mooshak2.Models.ViewModels;

namespace Mooshak2.Controllers
{
    public class AdminController : Controller
    {
        UserService uS = new UserService();
        CourseService cS = new CourseService();
        AdminUserViewModel aUVM = new AdminUserViewModel();

        //[Authorize (LoginService.userRole == 3)]   Gummi ætlaði að skoða þetta og svara okkur
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

            Course newCourse = new Course();
            newCourse = cS.CreateCourse(courseName, courseTeacher);

            if (string.IsNullOrEmpty(newCourse.courseName))
            {
                ModelState.AddModelError("courseName", "* Please enter a name for the course.");
            }

            if (string.IsNullOrEmpty(newCourse.courseTeacher))
            {
                ModelState.AddModelError("courseTeacher", "* Please pick a teacher for the course.");
            }

            if (ModelState.IsValid)
            {
                cS.SaveCourseToDatabase(newCourse);
                return RedirectToAction("HomePage");
            }

            return View(newCourse);
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

            
            uS.CreateUser(name, userName, ssn, email, password, userRole, course);

            return View("~/Views/Admin/HomePage.cshtml");

        }

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult ViewCourses()
        {
            List<Course> allCourses = new List<Course>();
            allCourses = cS.GetAllCourses();
            return View(allCourses);
        }

        public ActionResult ViewUsers()
        {
            List<Student> allStudents = new List<Student>();
            allStudents = uS.GetAllStudents();

            List<Teacher> allTeachers = new List<Teacher>();
            allTeachers = uS.GetAllTeachers();

            aUVM.students = allStudents;
            aUVM.teachers = allTeachers;

            return View(aUVM);
        }
    }
}