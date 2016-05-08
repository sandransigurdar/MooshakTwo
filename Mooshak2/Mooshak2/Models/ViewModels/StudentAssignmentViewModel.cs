using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.HomePageViewModel
{
    public class StudentAssignmentViewModel
    {
        public List<string> assignmentId { get; set; }
        public int studentId { get; set; }
        //public int assignmentId { get; set; }
        public int assignmentStatus { get; set; }
    }
}