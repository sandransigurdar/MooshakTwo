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
        public UserService(IMyDataContext context)
        {
            _db = context ?? new ApplicationDbContext();
        }


        AssignmentService aS = new AssignmentService();
        CourseStudent cS = new CourseStudent();
        LoginService lS = new LoginService();

        private IMyDataContext _db;


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

        public void CreateUser(int userRole, Student newStudent, Teacher newTeacher, string course)
        {
            int user = Convert.ToInt32(userRole);

            if (user == 1)
            {

                int courseId = 0;

                foreach (var item in _db.Courses)
                {
                    if (item.courseName == course)
                    {
                        courseId = item.id;
                    }
                }

                _db.Students.Add(newStudent);
                _db.SaveChanges();


                int studentId = 0;

                foreach (var item in _db.Students)
                {
                    if (item.name == newStudent.name)
                    {
                        studentId = item.id;
                    }
                }

                string rootPath = aS.GetPathForAssignments();
                string wholePath = rootPath + studentId;

                Directory.CreateDirectory(wholePath);

                cS.courseId = courseId;
                cS.studentId = studentId;

                _db.CourseStudents.Add(cS);
                _db.SaveChanges();
            }

            else if (user == 2)
            {
                foreach (var item in _db.Courses)
                {
                    if (item.courseName == course)
                    {
                        item.courseTeacher = newTeacher.name;
                    }
                }

                _db.SaveChanges();

                _db.Teachers.Add(newTeacher);
                _db.SaveChanges();

            }
        }
    }
}

