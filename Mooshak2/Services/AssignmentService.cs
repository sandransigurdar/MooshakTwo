using Mooshak2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models.ViewModels;
using Mooshak2.Models.Entity;

namespace Mooshak2.Services
{

    public class AssignmentService
    {
        private ApplicationDbContext _db;

        public AssignmentService()
        {
            _db = new ApplicationDbContext();
        }
      

        public List<Assignment> GetAllAssignments()
        {
            List <Assignment> allAssignments= new List<Assignment>();

            foreach (var item in _db.Assignments)
            {
                allAssignments.Add(item);
            }

            return allAssignments;

        }



        public List <AssignmentStudent> GetAssignmentStatus(int studentId)
        {
            List<AssignmentStudent> statuses = new List<AssignmentStudent>();
            foreach (var item in _db.AssignmentStudents)
            {
                if(studentId == item.studentId)
                {
                    statuses.Add(item);
                }
            }

            return statuses;

        }
    }
}