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

        AssignmentService aS = new AssignmentService();

        public ActionResult Index()
        {

            return View();

        }

        public void GetAssignmentFileFromUser(FormCollection formCollection)
        {
            string filePath = Request.Form["file"];
            string file = System.IO.File.ReadAllText(filePath);
            aS.SaveAssignment(file);
        }
    
    }
}