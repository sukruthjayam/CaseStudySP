using Microservice4.Controllers;
using Microservice4.Entities;
using Microservice4.Repositories;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject4
{
    [TestFixture]
    class LoginControllerTests
    {
        LoginController lc;
       
        [OneTimeSetUp]
        public void Initialize()
        {
            IConfiguration ObjConfiguration = new ConfigurationBuilder()
                                          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                        .AddJsonFile("appsettings.json")
                                          .Build();
            string str = ObjConfiguration.GetConnectionString("Constr");
            DbContextOptions<DBContext> options = new DbContextOptionsBuilder<DBContext>().UseSqlServer(str).Options;
            DBContext ObjContext = new DBContext(options);
            IRepository4 rp = new Repository4(ObjContext);
          
            lc = new LoginController(rp,ObjConfiguration);
        }
        [Test]
        [TestCase("sai", "sai345", 200)]
        [TestCase("test", "test44", 404)]
        public void Login_StatusCode(string uname, string password, int code)
        {
            var Result = lc.Login(uname, password) as ObjectResult;
            Assert.AreEqual(code, Result.StatusCode.Value);
        }

        [Test]
        public void AddUser_StatusCode()
        {
            UContext u = new UContext()
            { Uname = "user1", password = "pass1", usertype = "user", email = "abc@gmail.com", pnumber = 123, confirmed = "no" };
            var Result = lc.Signup(u) as ObjectResult;
            Assert.AreEqual(201, Result.StatusCode.Value);
        }
    }
}
