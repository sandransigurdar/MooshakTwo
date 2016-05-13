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

        [CustomAuthorization(3)]
        public ActionResult CreateCourse()
        {
            List<Teacher> ListOfAllTeachers = new List<Teacher>();
            ListOfAllTeachers = uS.GetAllTeachers();

            return View(ListOfAllTeachers);
        }

        [HttpPost]
        [CustomAuthorization(3)]
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

        [CustomAuthorization(3)]
        public ActionResult CreateUser()
        {
            List<Course> listOfAllCourses = new List<Course>();
            listOfAllCourses = cS.GetAllCourses();

            return View(listOfAllCourses);
        }

        [HttpPost]
        [CustomAuthorization(3)]
        public ActionResult CreateUser(FormCollection formCollection)
        {
            string name = Request.Form["name"];
            string userName = Request.Form["username"];
            string ssn = Request.Form["ssn"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string userRole = Request.Form["role"];
            string course = Request.Form["course"];

            int userRoleInt = Convert.ToInt32(userRole);

            
            if (string.IsNullOrEmpty(userRole))
            {
                Student userRoleNotPicker = new Student();
                ModelState.AddModelError("userrole", "* Please pick either a teacher or a student.");
                return View(userRoleNotPicker);
            }

            if (userRoleInt == 1)
            {
                Student newStudent = new Student();

                newStudent.name = name;
                newStudent.userName = userName;
                newStudent.ssn = ssn;
                newStudent.email = email;
                newStudent.password = password;
                newStudent.role = 1;

                if (string.IsNullOrEmpty(newStudent.name))
                {
                    ModelState.AddModelError("name", "* Please enter a name.");
                }
                if (string.IsNullOrEmpty(newStudent.userName))
                {
                    ModelState.AddModelError("username", "* Please enter a username.");
                }
                if (string.IsNullOrEmpty(newStudent.ssn))
                {
                    ModelState.AddModelError("ssn", "* Please enter a social security number.");
                }
                if (string.IsNullOrEmpty(newStudent.email))
                {
                    ModelState.AddModelError("email", "* Please enter a email.");
                }
                if (string.IsNullOrEmpty(newStudent.password))
                {
                    ModelState.AddModelError("password", "* Please enter a password.");
                }
                if (string.IsNullOrEmpty(course))
                {
                    ModelState.AddModelError("course", "* Please pick a course.");
                }

                if (ModelState.IsValid)
                {
                    Teacher emptyTeacher = new Teacher();
                    uS.CreateUser(1, newStudent, emptyTeacher, course);
                    return View("~/Views/Admin/HomePage.cshtml");
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();

                    return View("CreateUser", errors);
                }
            }

            else if (userRoleInt == 2)
            {
                Teacher newTeacher = new Teacher();

                newTeacher.name = name;
                newTeacher.userName = userName;
                newTeacher.ssn = ssn;
                newTeacher.email = email;
                newTeacher.password = password;
                newTeacher.role = 2;

                if (string.IsNullOrEmpty(newTeacher.name))
                {
                    ModelState.AddModelError("name", "* Please enter a name.");
                }
                if (string.IsNullOrEmpty(newTeacher.userName))
                {
                    ModelState.AddModelError("username", "* Please enter a username.");
                }
                if (string.IsNullOrEmpty(newTeacher.ssn))
                {
                    ModelState.AddModelError("ssn", "* Please enter a social security number.");
                }
                if (string.IsNullOrEmpty(newTeacher.email))
                {
                    ModelState.AddModelError("email", "* Please enter a email.");
                }
                if (string.IsNullOrEmpty(newTeacher.password))
                {
                    ModelState.AddModelError("password", "* Please enter a password.");
                }
                if (string.IsNullOrEmpty(newTeacher.password))
                {
                    ModelState.AddModelError("password", "* Please enter a password.");
                }
                if (string.IsNullOrEmpty(course))
                {
                    ModelState.AddModelError("course", "* Please pick a course.");
                }

                if (ModelState.IsValid)
                {
                    Student emptyStudent = new Student();
                    uS.CreateUser(2, emptyStudent, newTeacher, course);
                    return View("~/Views/Admin/HomePage.cshtml");
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();

                    return RedirectToAction("CreateUser", errors);
                }

                return View("~/Views/Admin/CreateUser.cshtml", newTeacher);
            }
            return View(/* ERROR */);
        }

        [CustomAuthorization(3)]
        public ActionResult HomePage()
        {
            return View();
        }

        [CustomAuthorization(3)]
        public ActionResult ViewCourses()
        {
            List<Course> allCourses = new List<Course>();
            allCourses = cS.GetAllCourses();
            return View(allCourses);
        }

        [CustomAuthorization(3)]
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