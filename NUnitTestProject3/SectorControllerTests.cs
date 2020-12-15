using Microservice3.Entities;
using Microservice3.Repositories;
using Microservice3.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace NUnitTestProject3
{
    [TestFixture]
    class SectorControllerTests
    {
        SectorListController seclist;
        SectorStockPriceController stpr;
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
            IRepository3 rp = new Repository3(ObjContext);
            seclist = new SectorListController(rp);
            stpr = new SectorStockPriceController(rp);
        }
        [Test]
        public void SectorList_StatusCode() {

            ObjectResult result = seclist.getList("finance") as ObjectResult;
            Assert.AreEqual(200, result.StatusCode.Value);
        }
        [Test]
        public void SectorList_Stat()
        {

            ObjectResult result = stpr.getSectorPrice("finance") as ObjectResult;
            Assert.AreEqual(200, result.StatusCode.Value);
        }

    }
}
