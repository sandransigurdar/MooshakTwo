using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models.Entity;

namespace Mooshak2.Models.ViewModels
{
    public class TeacherAssignmentViewModel
    {
        public List <Assignment> assignments { get; set; }
        public int  courseId { get; set; }
        public List <Student> students { get; set; }
        public List <Course> courses { get; set; }
    }
}