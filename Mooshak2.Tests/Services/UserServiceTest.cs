using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mooshak2.Services;
using Mooshak2.Models.Entity;

namespace Mooshak2.Tests.Services
{
	[TestClass]
	public class UserServiceTest
	{
		private UserService _service;

		[TestInitialize]
		public void Initialize()
		{
			var mockDb = new MockDataContext();
			var f1 = new Teacher
			{
				Id = 1,
				name = "Patrekur Patreksson",
				userName = "patti",
				ssn = "0806815856",
				email = "patrekur@ru.is",
				password = "patrekur123",
				role = 1,
			};
			mockDb.Teachers.Add(f1);
			var f2 = new Admin
			{
				id = 2,
				name = "AdminName",
				userName = "userName",
				ssn = "012345679",
				email = "email@ru.is",
				password = "password",
				role = 2,
			};
			mockDb.Admins.Add(f2);
			var f3 = new Student
			{
				id = 3,
				name = "StudentName",
				userName = "studentName",
				ssn = "002345679",
				email = "email@ru.is",
				password = "password",
				role = 3,
			};
			mockDb.Students.Add(f3);
			var f4 = new Course
			{
				id = 4,
				courseName = "courseName",
				courseTeacher = "courseTeacher",
			};
			mockDb.Courses.Add(f4);
            var f5 = new Student
            {
                id = 3,
                name = "SstudentName",
                userName = "sstudentName",
                ssn = "0002345679",
                email = "email@ru.is",
                password = "password",
                role = 4,
            };
            mockDb.Students.Add(f5);

            _service = new UserService(mockDb);
		}
		// Kerfisstjóri býr til notanda
		// GetAllTeachers og annað GetAllStudents

		[TestMethod]
		public void GetAllTeachersTest()
		{
			// Arrange
			Student newStudent = new Student();
			Teacher newTeacher = new Teacher();
			
			// Act
			var result = _service.GetAllTeachers();

            // Assert
            Assert.AreNotEqual(0, _service.GetAllTeachers().Count);
            Assert.AreEqual(1, _service.GetAllTeachers().Count);
            Assert.AreNotEqual(2, _service.GetAllTeachers().Count);
		}

        [TestMethod]
        public void GetAllStudentsTest()
        {
            // Arrange
            Student newStudent = new Student();
            Teacher newTeacher = new Teacher();


            // Act
            var result = _service.GetAllStudents();

            // Assert
            Assert.AreNotEqual(1, _service.GetAllStudents().Count);
            Assert.AreEqual(2, _service.GetAllStudents().Count);
            Assert.AreNotEqual(3, _service.GetAllStudents().Count);
        }

        [TestMethod]
        public void CreateStudentTest()
        {
            // Arrange: (Jarðvegurinn undirbúinn: búa til test gögn, input sem á að fara inn í föllin o.s.frv.)
            int userRole = 1;
            Student newStudent = new Student();
            Teacher newTeacher = new Teacher();
            string course = "4";

            // Act: (keyra aðgerðina sem á að prófa(yfirleitt ein lína)
            _service.CreateUser(userRole, newStudent, null, course);

            // Assert: (prófa, er svarið það sem við reiknuiðum með að fá, prófa hvaðeina sem þessi aðgerð)
            Assert.AreEqual(3, _service.GetAllStudents().Count);
            Assert.AreNotEqual(1, _service.GetAllStudents().Count);
            Assert.AreNotEqual(2, _service.GetAllStudents().Count);
        }

        [TestMethod]
        public void CreateTeacherTest()
        {
            // Arrange: (Jarðvegurinn undirbúinn: búa til test gögn, input sem á að fara inn í föllin o.s.frv.)
            int userRole = 2;
            Student newStudent = new Student();
            Teacher newTeacher = new Teacher();
            string course = "4";

            // Act: (keyra aðgerðina sem á að prófa(yfirleitt ein lína)
            _service.CreateUser(userRole, null, newTeacher, course);

            // Assert: (prófa, er svarið það sem við reiknuiðum með að fá, prófa hvaðeina sem þessi aðgerð)
            Assert.AreEqual(2, _service.GetAllTeachers().Count);
            Assert.AreNotEqual(1, _service.GetAllTeachers().Count);
            Assert.AreNotEqual(3, _service.GetAllTeachers().Count);
        }
    }
}