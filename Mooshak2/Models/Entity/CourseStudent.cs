using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entity
{
    public class CourseStudent
    {
        public int id { get; set; }
        public int courseId { get; set; }
        public int studentId { get; set; }
    }
}