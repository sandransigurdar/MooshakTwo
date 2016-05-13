using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mooshak2.Services;
using Mooshak2.Models;
using Mooshak2.Models.Entity;


// LoginService test

namespace Mooshak2.Tests.Services
{
    [TestClass]
    public class AssignmentServiceTest
    {
        private AssignmentService _service;

        [TestInitialize]
        public void Initialize()
        {
            // Kennari setur inn nýtt verkefni. 
            var mockDb = new MockDataContext();
            var f1 = new Teacher
            {
                Id = 1,
                name = "Patrekur Patreksson",
                userName = "patti",
                ssn = "0806815856",
                email = "patrekur@ru.is",
                password = "patrekur123",
                role = 2,

            };
            mockDb.Teachers.Add(f1);
            var f2 = new Teacher
            {
                Id = 2,
                name = "Guðmundur Guðmunsso",
                userName = "gummi",
                ssn = "0806813459",
                email = "gudmundur@ru.is",
                password = "gudmundur123",
                role = 2,

            };
            mockDb.Teachers.Add(f2);
            var f3 = new Teacher
            {
                Id = 4,
                name = "Sigurður Sigurðsson",
                userName = "siggi",
                ssn = "0806814567",
                email = "sigurdur@ru.is",
                password = "sigurdur123",
                role = 2,

            };
            mockDb.Teachers.Add(f3);

            _service = new AssignmentService(mockDb);
        }

        [TestMethod]
        public void SaveChangesToDatabaseTest()
        {
            // Arrange: (Jarðvegurinn undirbúinn: búa til test gögn, input sem á að fara inn í föllin o.s.frv.)
            Assignment newAssignment = new Assignment();
            newAssignment.assignmentName = "Name";
            newAssignment.assignmentSubName = "subName";
            newAssignment.description = "description";
            newAssignment.dueDate = DateTime.Parse("11/11/2016");
            newAssignment.input = "input";
            newAssignment.correctOutput = "correctOutput";
            
            // Act: (keyra aðgerðina sem á að prófa(yfirleitt ein lína)
            _service.SaveChangesToDatabase(newAssignment);

            // Assert: (prófa, er svarið það sem við reiknuiðum með að fá, prófa hvaðeina sem þessi aðgerð)
            Assert.AreNotEqual(0, _service.GetAllAssignments().Count);
            Assert.AreEqual(1, _service.GetAllAssignments().Count);
            Assert.AreNotEqual(2, _service.GetAllAssignments().Count);

        }
    }
}

/*    Sýnidæmi um leap year, ættum að gera amk 4 test fyrir það fall)
    [TestMethod]
    public void TestIsLeapYearModulus400()
    {
        const int year = 2000;

        var result = IsLeapYear(year);

        Assert.IsTrue(result);
    }

    (Ættum svo að gera annað test fyrir Modulus100 sem er ekki fyrir 400, o.s.frv...)*/
