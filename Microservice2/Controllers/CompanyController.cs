using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microservice2.Repository;
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
        public IActionResult getCompanyDetails()
        {
            var ls = repo.getCompanyDetails();
            if (ls.Count() == 0)
            {
                return NoContent();
            }
            return Ok(ls);
        }
        [HttpGet("{Cpattr}")]
        public IActionResult getMatchingCompanies(string Cpattr)
        {

            var ls = repo.getMatchingCompanies(Cpattr);
            if (ls.Count() == 0) {

                return NotFound();
            }
            return Ok(ls);
        }

        [HttpGet("{cid}/{fm}/{to}")]
        public IActionResult getCompanyStockPrice(int cid, DateTime fm, DateTime to)
        {
            var Total_Price = repo.getCompanyStockPrice(cid, fm,to);
            
            return Ok(Total_Price);
        }
       




    }
}
