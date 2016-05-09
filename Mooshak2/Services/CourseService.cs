using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models.Entity;
using Mooshak2.Models;

namespace Mooshak2.Services
{
    public class CourseService
    {
        private ApplicationDbContext _db;

        public CourseService()
        {
            _db = new ApplicationDbContext();
        }

        public List<Course> GetAllCourses()
        {
            List<Course> allCourses = new List<Course>();

            foreach (var item in _db.Courses)
            {
                allCourses.Add(item);
            }

            return allCourses;

        }

        public void CreateCourse(string name, string teacher)
        {
            List<Course> allCourses = new List<Course>();

            foreach (var item in _db.Courses)
            {
                allCourses.Add(item);
            }

            int newId = allCourses.Count + 1;

            foreach (var item in _db.Courses)
            {
                if (item.id == newId)
                {
                    item.id = 8;
                    item.courseName = name;
                    item.courseTeacher = teacher;
                }
            }
        }
    }
}