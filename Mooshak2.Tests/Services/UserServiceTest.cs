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

			_service = new UserService(mockDb);
		}
		// Kerfisstjóri býr til notanda
		// GetAllTeachers og annað GetAllStudents

		[TestMethod]
		public void GetAllTeachersTest()
		{
			// Arrange
			int userRole = 1;
			Student newStudent = new Student();
			Teacher newTeacher = new Teacher();
			string course = "Api";
			
			// Act
			var result = _service.GetAllTeachers();

			// Assert
			Assert.AreEqual(1, _service.GetAllTeachers().Count);
		}
	}
}

// Athuga hvort réttur user verður til