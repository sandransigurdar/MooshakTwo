using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2.Services;
using Mooshak2.Models;
using Mooshak2.Models.Entity;
using Mooshak2.Models.ViewModels;

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
            
           

            AssignmentService aS = new AssignmentService();
            List <Assignment> ListOfAllAssignments = new List<Assignment>();
            ListOfAllAssignments = aS.GetAllAssignments();

            UserService uS = new UserService();

            List<AssignmentStudent> StatusOfAssignments = new List<AssignmentStudent>();
            Student student = uS.getStudentByName(LoginService.nameOfLoggedInUser);

            StatusOfAssignments = aS.GetAssignmentStatus(student.id);

            StudentAssignmentViewModel sAVM = new StudentAssignmentViewModel();
            sAVM.currentStudentId = student.id;
            sAVM.assignments = ListOfAllAssignments;
            sAVM.assignmentStudent = StatusOfAssignments;

            return View(sAVM);
        }

    }
}