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
   

        private AssignmentService service = new AssignmentService();



        //dæmi frá Dabs

        public ActionResult SkodaNemendur(int id)

        {

            //var viewModel = service.GetAssignmentByID(id);



            return View(/*viewModel*/);

        }

        }
}