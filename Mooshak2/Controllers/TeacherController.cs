﻿using System;
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
            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }

    }
}