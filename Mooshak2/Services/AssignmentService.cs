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
        LoginService lS = new LoginService();

        private ApplicationDbContext _db;

        public AssignmentService()
        {
            _db = new ApplicationDbContext();
        }


        public List<Assignment> GetAllAssignments()
        {
            List<Assignment> allAssignments = new List<Assignment>();

            foreach (var item in _db.Assignments)
            {
                allAssignments.Add(item);
            }

            return allAssignments;

        }



        public List<AssignmentStudent> GetAssignmentStatus(int studentId)
        {
            List<AssignmentStudent> statuses = new List<AssignmentStudent>();
            foreach (var item in _db.AssignmentStudents)
            {
                if (studentId == item.studentId)
                {
                    statuses.Add(item);
                }
            }

            return statuses;

        }

        public Assignment CreateAssignment(string name, string subName, string description, DateTime date, string input, string correctOutput)
        {
            Assignment newAssignment = new Assignment();
            newAssignment.assignmentName = name;
            newAssignment.assignmentSubName = subName;
            newAssignment.description = description;
            newAssignment.dueDate = date;
            newAssignment.input = input;
            newAssignment.correctOutput = correctOutput;

            return newAssignment;

        }

        public void SaveAssignment(string assignmentName, HttpPostedFileBase filePath)
        {

            int studentId = 0;
            

            string loggedInUser = LoginService.nameOfLoggedInUser;

            foreach (var item in _db.Students)
            {
                if (loggedInUser == item.userName)
                {
                    studentId = item.id;
                }
            }

            if(!System.IO.Directory.Exists(""))
            {

            }
            string rootOfProjectPath = lS.GetPathForAssignments() + studentId + "\\" + assignmentName;
            System.IO.FileStream outStream = new System.IO.FileStream(rootOfProjectPath, System.IO.FileMode.CreateNew);

            filePath.InputStream.CopyTo(outStream);
            outStream.Flush();
            outStream.Dispose();

        }

        public void SaveChangesToDatabase(Assignment newAssignment)
        {
            _db.Assignments.Add(newAssignment);
            _db.SaveChanges();
        }

        /* public int GetAssignmentStatus()
         {
            //TODO
         }*/



    }
}
