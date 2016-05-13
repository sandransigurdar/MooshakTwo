﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mooshak2.Services;
using Mooshak2.Models;


// LoginService test

namespace Mooshak2.Tests.Services
{
    [TestClass]
    public class LoginServiceTest
    {
        private LoginService _service;

        [TestInitialize]
        public void Initialize()
        {
            var mockDb = new MockDataContext();
            var f1 = new ApplicationDbContext
            {
                /*Assignments = 1;
                Courses = 2;

                */

                // stuff;

            };
            _service = new LoginService(mockDb);
        }

        [TestMethod]
        public void Authenticate(string name, string password)
        {
            // Arrange: (Jarðvegurinn undirbúinn: búa til test gögn, input sem á að fara inn í föllin o.s.frv.)
            LoginService service = new LoginService();

            // Act: (keyra aðgerðina sem á að prófa(yfirleitt ein lína)
            var result = service.Authenticate(name, password);

            // Assert: (prófa, er svarið það sem við reiknuiðum með að fá, prófa hvaðeina sem þessi aðgerð)
            Assert.AreEqual(404, result);

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
