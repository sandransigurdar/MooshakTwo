using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models.Entity;
using Mooshak2.Models;
using System.ComponentModel.DataAnnotations;

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

        public Course CreateCourse(string name, string teacher)
        {

            Course newCourse = new Course();
            newCourse.courseName = name;
            newCourse.courseTeacher = teacher;

            return newCourse;
        }

        public void SaveCourseToDatabase(Course newCourse)
        {
            _db.Courses.Add(newCourse);
            _db.SaveChanges();
        }
    }
}