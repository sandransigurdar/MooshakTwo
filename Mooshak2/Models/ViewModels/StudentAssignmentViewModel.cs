using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models.Entity;

namespace Mooshak2.Models.ViewModels
{
    public class StudentAssignmentViewModel
    {
        public List <Assignment> assignments { get; set; }
        public List <AssignmentStudent> assignmentStudent { get; set;}
        public int currentStudentId { set; get; }
    }
}