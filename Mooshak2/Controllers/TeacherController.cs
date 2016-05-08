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
    public class TeacherController : Controller
    {
        public ActionResult CreateAssignment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAssignment(FormCollection formCollection)
        {
            string name = Request.Form["name"];
            string subname = Request.Form["subname"];
            string description = Request.Form["description"];
            //date date = Request.Form["date"];
            string input = Request.Form["input"];
            string correctoutput = Request.Form["correctoutput"];
            


            /*
         UserService uS = new UserService();
         CourseService cS = new CourseService();
         AssignmentService aS = new AssignmentService();



         List <Student> listOfAllStudents = new List <Student> ();
         listOfAllStudents = uS.GetAllStudents();


         List<Course> listOfAllCourses = new List<Course>();
         listOfAllCourses = cS.GetAllCourses();

         List<Assignment> listOfAllAssignments = new List<Assignment>();
         listOfAllAssignments = aS.GetAllAssignments();

         TeacherAssignmentViewModel tAVM = new TeacherAssignmentViewModel();
         */
            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }

    }
}