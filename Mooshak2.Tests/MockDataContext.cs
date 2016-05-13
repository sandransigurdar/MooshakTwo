using System;
using System.Data.Entity;
using Mooshak2.Models;
using Mooshak2.Models.Entity;
using Mooshak2.Services;
using System.Linq;

namespace Mooshak2.Tests
{
    public class MockDataContext : IMyDataContext
    {
        public MockDataContext()
        {
            // We're setting our DbSets to be InMemoryDbSets rather than using SQL Server.            

            Assignments = new InMemoryDbSet<Assignment>();
            Courses = new InMemoryDbSet<Course>();
            Students = new InMemoryDbSet<Student>();
            Teachers = new InMemoryDbSet<Teacher>();
            Admins = new InMemoryDbSet<Admin>();
            AssignmentStudents = new InMemoryDbSet<AssignmentStudent>();
            CourseStudents = new InMemoryDbSet<CourseStudent>();
        }

        public IDbSet<Assignment> Assignments { get; set; }        
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Teacher> Teachers { get; set; }
        public IDbSet<Admin> Admins { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<AssignmentStudent> AssignmentStudents { get; set; }
        public IDbSet<CourseStudent> CourseStudents { get; set; }


        public int SaveChanges()
        {
            // Pretend that each entity gets a database id when we hit save.
            int changes = 0;

            return changes;
        }

        public void Dispose()
        {
            // Do nothing!
        }
    }
}
