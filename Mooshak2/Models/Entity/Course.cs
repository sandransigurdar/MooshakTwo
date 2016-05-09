using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entity
{
    public class Course
    {
        public int id { get; set; }
        public string courseName { get; set; }
        public string courseTeacher { get; set; }
    }
}