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
        AssignmentService aS = new AssignmentService();

        public ActionResult CreateAssignment()
        {
            return View();
        }

        [HttpPost]
        [CustomAuthorization(2)]
        public ActionResult CreateAssignment(FormCollection formCollection)
        {
            string name = Request.Form["name"];
            string subname = Request.Form["subname"];
            string description = Request.Form["description"];
            string dateString = (Request.Form["date"]);
            string input = Request.Form["input"];
            string correctoutput = Request.Form["correctoutput"];

            DateTime date = DateTime.Now;

            if(!(string.IsNullOrEmpty(dateString)))
            {
                date = DateTime.Parse(dateString);
            }

            Assignment newAssignment = new Assignment();
            newAssignment = aS.CreateAssignment(name, subname, description, date, input, correctoutput);

            if (string.IsNullOrEmpty(newAssignment.assignmentName))
            {
                ModelState.AddModelError("name", "* Please enter a name.");
            }
            if (string.IsNullOrEmpty(newAssignment.assignmentSubName))
            {
                ModelState.AddModelError("subName", "* Please enter a subname.");
            }
            if (string.IsNullOrEmpty(newAssignment.description))
            {
                ModelState.AddModelError("description", "* Please enter a description.");
            }
            if (string.IsNullOrEmpty(newAssignment.description))
            {
                ModelState.AddModelError("date", "* Please enter a date.");
            }
            if (string.IsNullOrEmpty(newAssignment.input))
            {
                ModelState.AddModelError("input", "* Please enter input.");
            }
            if (string.IsNullOrEmpty(newAssignment.correctOutput))
            {
                ModelState.AddModelError("correctOutput", "* Please enter a correct output.");
            }

            if(ModelState.IsValid)
            {
                aS.SaveChangesToDatabase(newAssignment);
                return RedirectToAction("HomePage");
            }

            return View(newAssignment);
        }

        [CustomAuthorization(2)]
        public ActionResult HomePage()
        {
            return View();
        }
    }
}