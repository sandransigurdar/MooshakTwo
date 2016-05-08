using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.ViewModels
{
    public class NewCourseViewModel
    {
        public List<int> courseId { get; set; }
        public List<int> userId { get; set; }
    }
}