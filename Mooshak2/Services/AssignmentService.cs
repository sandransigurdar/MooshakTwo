using Mooshak2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models.ViewModels;
using Mooshak2.Models.Entity;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace Mooshak2.Services
{
    public class AssignmentService
    {

        public AssignmentService(IMyDataContext context)
        {
            _db = context ?? new ApplicationDbContext();
        }

        LoginService lS = new LoginService();

        private IMyDataContext _db;

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

            foreach (var item in _db.Students)
            {
                if (loggedInUser == item.userName)
                {
                    studentId = item.id;
                }
            }

            if (studentId == 404)
            {
                //return View("~/Views/Shared/Error.cshtml");
            }

            string rootOfProjectPath = GetPathForAssignments() + studentId + "\\";

            if (!System.IO.Directory.Exists(rootOfProjectPath))
            {
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(rootOfProjectPath, createText);
            }

            rootOfProjectPath += assignmentId + ".cpp";
            System.IO.FileStream outStream = new System.IO.FileStream(rootOfProjectPath, System.IO.FileMode.CreateNew);
            filePath.InputStream.CopyTo(outStream);
            outStream.Flush();
            outStream.Dispose();

            return rootOfProjectPath;
        }

        public void SaveChangesToDatabase(Assignment newAssignment)
        {
            _db.Assignments.Add(newAssignment);
            _db.SaveChanges();
        }

        public string ReturnCode(string filePath)

        {
            if (!File.Exists(filePath))
            {
                //return View("Error");
            }

            string readText = File.ReadAllText(filePath);

            return readText;
        }

        public void CompileAndReturnStatusOfAssignment(string assignmentId, string code)
        {
            int assignmentIdInt = int.Parse(assignmentId);
            string workingFolder = GetPathForAssignments();
            string cppFileName = assignmentId + ".cpp";
            string exeFilePath = workingFolder + assignmentId + ".exe";

            System.IO.File.WriteAllText(workingFolder + cppFileName, code);

            var compilerFolder = ConfigurationSettings.AppSettings["VisualStudioCompilerPath"];

            List<string> lines = new List<string>();

            Process compiler = new Process();
            compiler.StartInfo.FileName = "cmd.exe";
            compiler.StartInfo.WorkingDirectory = workingFolder;
            compiler.StartInfo.RedirectStandardInput = true;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.StartInfo.UseShellExecute = false;

            compiler.Start();
            compiler.StandardInput.WriteLine("\"" + compilerFolder + "vcvars32.bat" + "\"");
            compiler.StandardInput.WriteLine("cl.exe /nologo /EHsc " + cppFileName);
            compiler.StandardInput.WriteLine("exit");
            string output = compiler.StandardOutput.ReadToEnd();
            compiler.WaitForExit();
            compiler.Close();

            if (System.IO.File.Exists(exeFilePath))
            {
                var processInfoExe = new ProcessStartInfo(exeFilePath, "");
                processInfoExe.UseShellExecute = false;
                processInfoExe.RedirectStandardOutput = true;
                processInfoExe.RedirectStandardError = true;
                processInfoExe.CreateNoWindow = true;

                using (var processExe = new Process())
                {
                    processExe.StartInfo = processInfoExe;
                    processExe.Start();

                    // In this example, we don't try to pass any input
                    // to the program, but that is of course also
                    // necessary. We would do that here, using
                    // processExe.StandardInput.WriteLine(), similar
                    // to above.
                    // We then read the output of the program:
                    string input = "";

                    foreach (var item in _db.Assignments)
                    {
                        if (assignmentIdInt == item.id)
                        {
                            input += item.input;
                        }

                    }

                    while (!processExe.StandardOutput.EndOfStream)
                    {
                        //processExe.StandardInput.WriteLine(input);
                        lines.Add(processExe.StandardOutput.ReadLine());
                    }
                }
            }
            List<string> codeStringList = lines;


            string codeResult = "";
            foreach (var item in codeStringList)
            {
                codeResult += item;
            }

            //foreach(var item in _db.AssignmentStudents)
            //{
            //    if(assignmentId == item.)
            //    {

            //    }
            //}

            string nameOfLoggedInUser = LoginService.nameOfLoggedInUser;



            int status = 0;
            int studentId = 0;

            foreach (var item in _db.Students)
            {
                if (nameOfLoggedInUser == item.userName)
                {
                    studentId = item.id;
                }
            }


            foreach (var item in _db.Assignments)

            {
                if (codeResult == item.correctOutput && assignmentIdInt == item.id)
                {
                    status = 1;
                }
                else if (codeResult != item.correctOutput && assignmentIdInt == item.id)
                {
                    status = 2;
                }
            }


            AssignmentStudent oAS = null;

            foreach (var item in _db.AssignmentStudents)
            {
                if (item.assignmentId == assignmentIdInt && item.studentId == studentId)
                {
                    oAS = item;
                }
            }

            if (oAS != null)
            {
                _db.AssignmentStudents.Remove(oAS);
            }

            AssignmentStudent nAS = new AssignmentStudent();
            nAS.assignmentId = assignmentIdInt;
            nAS.hasBeenTurnedIn = status;
            nAS.studentId = studentId;

            _db.AssignmentStudents.Add(nAS);
            _db.SaveChanges();

        }
    }
}