using Mooshak2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models.ViewModels;
using Mooshak2.Models.Entity;
using System.IO;
using System.Diagnostics;

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

        public string GetPathForAssignments()
        {
            string root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            root = root.Remove(root.Length - 3);
            string path = "StudentAssignments\\";
            string wholePath = root + path;
            wholePath = wholePath.Remove(0, 6);

            return wholePath;
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

        public string SaveAssignment(string assignmentId, HttpPostedFileBase filePath)
        {
            var bla = filePath;

            int studentId = 404;

            string loggedInUser = LoginService.nameOfLoggedInUser;

            foreach(var item in _db.Students)
            {
                if(loggedInUser == item.userName)
                {
                    studentId = item.id;
                }
            }

            if(studentId == 404)
            {
                //return View("~/Views/Shared/Error.cshtml");
            }

            string rootOfProjectPath = GetPathForAssignments() + studentId + "\\"  /* + assignmentId + ".cpp"*/;

            if (!System.IO.Directory.Exists(rootOfProjectPath))
            {
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(rootOfProjectPath, createText);
            }
            rootOfProjectPath +=  assignmentId + ".cpp";

            

            System.IO.FileStream outStream = new System.IO.FileStream(rootOfProjectPath, System.IO.FileMode.CreateNew);

            filePath.InputStream.CopyTo(outStream);
            outStream.Flush();
            outStream.Dispose();
            //string readText = File.ReadAllText(rootOfProjectPath);

            return rootOfProjectPath;
        }

        public void SaveChangesToDatabase(Assignment newAssignment)
        {
            _db.Assignments.Add(newAssignment);
            _db.SaveChanges();
        }

        

        public string ReturnCode(string assignmentId, string filePath)

        {
            //TODO FINNA SKJAL


            
            //string path = @"c:\test\bla.cpp";

            if (!File.Exists(filePath))
            {
                //return View("Error");
            }
            
            string readText = File.ReadAllText(filePath);

            return readText;
        }

        public void CompileAndReturnStatusOfAssignment(string code)
        {
        }



    }
}
