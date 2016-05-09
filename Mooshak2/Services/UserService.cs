using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models;
using Mooshak2.Models.Entity;
using System.Web.Security;
using Mooshak2.Models.ViewModels;

namespace Mooshak2.Services
{
    public class UserService
    {
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

            List<Student> getNumberOfStudents = new List<Student>();
            List<Teacher> getNumberOfTeachers = new List<Teacher>();

            if (user == 1)
            {
                foreach (var item in _db.Students)
                {
                    getNumberOfStudents.Add(item);
                }

                int studentId = getNumberOfStudents.Count + 1;

                foreach (var student in _db.Students)
                {
                    Student newStudent = new Student();

                    if (student.id == studentId)
                    {
                        student.name = name;
                        student.userName = userName;
                        student.ssn = ssn;
                        student.email = email;
                        student.password = password;
                        student.role = 1;
                        //student.????//COURSE O.S.F.V

                        _db.Students.Add(student);
                        _db.SaveChanges();

                    }
                }
            }

            else if (user == 2)
            {
                foreach (var item in _db.Teachers)
                {
                    getNumberOfTeachers.Add(item);
                }

                int teacherId = getNumberOfTeachers.Count + 1;

                foreach (var teacher in _db.Teachers)
                {
                    if (teacher.id == teacherId)
                    {
                        teacher.name = name;
                        teacher.userName = userName;
                        teacher.ssn = ssn;
                        teacher.email = email;
                        teacher.password = password;
                        teacher.role = 2;

                        _db.Teachers.Add(teacher);
                        _db.SaveChanges();
                    }
                }
            }
        }
    }
}

