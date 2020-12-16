using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microservice5.Controllers;
using Microservice5.Repository;
using Microsoft.EntityFrameworkCore;
using Microservice5.Entities;
using Microsoft.AspNetCore.Mvc;

namespace NUnitTestProject5
{
    [TestFixture]
    class StockExchangeControllerTests
    {
        StockExchangeController se;
        SEContext se_data;
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
            IRepository5 rp = new Repository5(ObjContext);
            se = new StockExchangeController(rp);
            se_data = new SEContext(){ name = "demo", brief = "demo", address = "demo", remarks = "demo" };
        }
        [Test]
        public void getStockExchanges_StatusCode()
        {
            var Result = se.getSEData() as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }
        [Test]
        public void getStockExchanges_List()
        {
            var Result = se.getSEData() as ObjectResult;
            Assert.IsInstanceOf<IEnumerable<SEContext>>(Result.Value);
        }

        
        [Test]        
        public void getCompany_SE_StatusCode()
        {   
            var Result = se.getCompData("nse") as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode.Value);
        }

        [Test]
        public void getCompany_SE_List()
        {
            var Result = se.getCompData("nse") as ObjectResult;
            Assert.IsInstanceOf<IEnumerable<CContext>>(Result.Value);
        }

        [Test]
        public void AddStockExchange_StatusCode()
        {
            var Result = se.addSEdata(se_data) as ObjectResult;
            Assert.AreEqual(201, Result.StatusCode.Value);
        }

        

    }
   
}
