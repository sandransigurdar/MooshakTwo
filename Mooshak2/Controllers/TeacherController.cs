using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult CreateAssignment()
        {


            /* List<Student> listOfAllStudents = new List<Student>();
             UserService us = new UserService();
             listOfStudents = us.GetAllStudents();*/

            /* List<Course> listOfCourses = new List<Course>();
           CourseService cs = new CourseService();
           //listOfCourses = cs. */



            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }

    }
}