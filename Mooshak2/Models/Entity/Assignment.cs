using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entity
{
    public class Assignment
    {
        public int id { get; set; }
        public string assignmentName { get; set; }
        public string assignmentSubName { get; set; }
        public string description { get; set; }
        public DateTime dueDate { get; set; }
        public List<string> allHandIns { get; set; }
        public string input { get; set; }
        public string correctOutput { get; set; }
       
    }
}