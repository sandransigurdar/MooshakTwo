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
            DateTime date = DateTime.Parse(Request.Form["date"]);
            string input = Request.Form["input"];
            string correctoutput = Request.Form["correctoutput"];

            AssignmentService aS = new AssignmentService();
            aS.CreateAssignment(name, subname, description, date, input, correctoutput);

            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }

    }
}