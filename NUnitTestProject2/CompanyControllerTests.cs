using Microservice2.Controllers;
using Microservice2.Entities;
using Microservice2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject2
{
    [TestFixture]
    class CompanyControllerTests
    {
        CompanyController Comp;
        IPOController ipo;
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
            IRepository2 rp = new Repository2(ObjContext);
            Comp = new CompanyController(rp);
            ipo = new IPOController(rp);
        }
        [Test]
        public void CompanyDetails_StatusCode() { 
        
        var result=Comp.getCompanyDetails() as ObjectResult;
            Assert.AreEqual(200, result.StatusCode.Value);
        }

        [Test]
        public void CompanyDetails_list()
        {
            var result = Comp.getCompanyDetails() as ObjectResult;
            Assert.IsInstanceOf<IEnumerable<CContext>>(result.Value);
        }

        [Test]
        public void IPODetails_list()
        {
            var result =  ipo.getcompanyipodetails("SG") as ObjectResult ;
            Assert.AreEqual(200, result.StatusCode.Value);
        }

        [Test]
        public void CompanyStockPrice() {

            DateTime fm = new DateTime(2008 , 11 , 11, 13,23,44) ;
            DateTime to = new DateTime(2008, 11, 13, 13, 23, 44);
            var result = Comp.getCompanyStockPrice(3, fm,to) as ObjectResult;
            Assert.IsInstanceOf<IEnumerable<SPContext>>(result.Value);
        }
      
    }
}
