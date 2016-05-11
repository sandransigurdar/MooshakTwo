using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Mooshak2.Models;
using Mooshak2.Models.Entity;
using System.Web.Security;
using Mooshak2.Models.ViewModels;
using System.IO;
using System.ComponentModel.DataAnnotations;


namespace Mooshak2.Services
{
    public class UserService
    {
        CourseStudent cS = new CourseStudent();
        LoginService lS = new LoginService();

        private ApplicationDbContext _db;


        public UserService()
        {
            _db = new ApplicationDbContext();
        }

        public List<Student> GetAllStudents()
        {
            List<Student> allStudents = new List<Student>();

            foreach (var student in _db.Students)
            {
                allStudents.Add(student);
            }

            return allStudents;
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> allTeachers = new List<Teacher>();

            foreach (var teacher in _db.Teachers)
            {
                allTeachers.Add(teacher);
            }

            return allTeachers;
        }

        public Student getStudentByName(string name)
        {
            Student student = (from x in _db.Students
                               where x.userName == name
                               select x).FirstOrDefault();

            return student;
        }

        public void CreateUser(string name, string userName, string ssn, string email, string password, string userRole, string course)
        {
            int user = Convert.ToInt32(userRole);

            if (user == 1)
            {

                Student newStudent = new Student();

                newStudent.name = name;
                newStudent.userName = userName;
                newStudent.ssn = ssn;
                newStudent.email = email;
                newStudent.password = password;
                newStudent.role = 1;

                int courseId = 0;

                foreach (var item in _db.Courses)
                {
                    
                    if(item.courseName == course)
                    {
                        courseId = item.id;
                    }
                }

                _db.Students.Add(newStudent);
                _db.SaveChanges();

                
                int studentId = 0;

                foreach(var item in _db.Students)
                {
                    if (item.name == name)
                    {
                        studentId = item.id;
                    }
                }

                string rootPath = lS.GetPathForAssignments();
                string wholePath = rootPath + studentId;

                Directory.CreateDirectory(wholePath);

                
                cS.courseId = courseId;
                cS.studentId = studentId;

                _db.CourseStudents.Add(cS);
                _db.SaveChanges();
            }

            else if(user == 2)
            {
                Teacher newTeacher = new Teacher(); 

                newTeacher.name = name;
                newTeacher.userName = userName;
                newTeacher.ssn = ssn;
                newTeacher.email = email;
                newTeacher.password = password;
                newTeacher.role = 2;


                foreach(var item in _db.Courses)
                {
                    if(item.courseName == course)
                    {
                        item.courseTeacher = name;
                        
                    }
                }

                _db.SaveChanges();

                _db.Teachers.Add(newTeacher);
                _db.SaveChanges();

            }
        }
    }
}

