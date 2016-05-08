﻿using System;
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

        public List <Student> GetAllStudents()
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
    }
}
