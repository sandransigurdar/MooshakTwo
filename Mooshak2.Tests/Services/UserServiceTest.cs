using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mooshak2.Services;
using Mooshak2.Models.Entity;

// Kerfisstjóri býr til notanda

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
                role = 2,
            };
            mockDb.Teachers.Add(f1);
            var f2 = new Teacher
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
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
