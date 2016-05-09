using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models.Entity;

namespace Mooshak2.Models.ViewModels
{
    public class NewCourseViewModel
    {
        public List <Course> courses { get; set; }
        public List <int> userId { get; set; }
    }
}