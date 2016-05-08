using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entity
{
    public class AssignmentStudent
    {
        public int id { get; set; }
        public int studentId { get; set; }
        public int assignmentId { get; set; }
        public int hasBeenTurnedIn { get; set; }
    }
}