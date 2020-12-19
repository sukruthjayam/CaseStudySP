using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microservice2.Repository;
using Microservice2.Entities;
namespace Microservice2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        IRepository2 repo;
        public CompanyController(IRepository2 repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult getCompanyDetails()
        {
            var ls = repo.getCompanyDetails();
            if (ls.Count() == 0)
            {
                return NotFound();
            }
            return Ok(ls);
        }

        [HttpGet("{cid}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult getCompanyDetailsByID(int cid)
        {
            var ls = repo.getCompanyDetailsByID(cid);
            if (ls==null)
            {
                return NotFound();
            }
            return Ok(ls);
        }

        [HttpDelete("{cid}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult deleteCompany(int cid)
        {
            var ls = repo.delCompanyDetails(cid);
            if (ls == null)
            {
                return NotFound();
            }
            return Ok(ls);
        }

        [HttpPost]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult addCompany([FromBody] CContext c)
        {
            var ls = repo.addCompany(c);
           
            return Ok(ls);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public IActionResult UpdateCompany([FromBody] CContext c)
        {
            var ls = repo.UpdateCompany(c);

            return Ok("update successful");
        }

        [HttpGet("srchcomp/{Cpattr}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult getMatchingCompanies(string Cpattr)
        {

            var ls = repo.getMatchingCompanies(Cpattr);
            if (ls.Count() == 0)
            {

                return NotFound();
            }
            return Ok(ls);
        }

        [HttpGet("{cid}/{fm}/{to}")]
        [ProducesResponseType(200)]
        public IActionResult getCompanyStockPrice(int cid, DateTime fm, DateTime to)
        {
            var Total_Price = repo.getCompanyStockPrice(cid, fm,to);
            
            return Ok(Total_Price);
        }
       




    }
}
