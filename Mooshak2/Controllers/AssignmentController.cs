using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2.Services;

namespace Mooshak2.Controllers
{
    public class AssignmentController : Controller
    {
        LoginService lS = new LoginService();
        AssignmentService aS = new AssignmentService();


        public ActionResult Index()
        {

            return View();

        }

        [HttpPost]
        public ActionResult GetAssignmentFileFromUser(FormCollection formCollection)
        {

            string assignmentId = Request.Form["asName"];
            
            var fileName = Request.Files.Get("file");

            string pathToFile = aS.SaveAssignment(assignmentId , fileName);

            string code = aS.ReturnCode(assignmentId, pathToFile);

            return View("~/Views/Student/HomePage.cshtml");
        }
    }
}