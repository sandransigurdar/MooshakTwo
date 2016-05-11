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

        public void CreateAssignment(string name, string subName, string description, DateTime date, string input, string correctOutput)
        {
            Assignment newAssignment = new Assignment();
            newAssignment.assignmentName = name;
            newAssignment.assignmentSubName = subName;
            newAssignment.description = description;
            newAssignment.dueDate = date;
            newAssignment.input = input;
            newAssignment.correctOutput = correctOutput;

            _db.Assignments.Add(newAssignment);
            _db.SaveChanges();

        }

        public void SaveAssignment(string assignmentCode)
        {

            int studentId =0;
            //string assignmentName;
            
            string loggedInUser = LoginService.nameOfLoggedInUser;

            foreach (var item in _db.Students)
            {
                if(loggedInUser == item.name)
                {
                    studentId = item.id;
                }
            }


            string assignmentPath = lS.GetPathForAssignments();
            string wholePath = assignmentPath + studentId;

            //System.IO.File.WriteAllText(wholePath + );



        }

       /* public int GetAssignmentStatus()
        {

        }*/

       

    }
}