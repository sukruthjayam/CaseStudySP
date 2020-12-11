using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microservice2.Repository;
namespace Microservice2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Microservice2Controller : ControllerBase
    {
        IRepository2 repo;
        public Microservice2Controller(IRepository2 repo)
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

        [HttpGet]
        public IActionResult getCompanyIPODetails(string Coname)
        {
            var ls = repo.getCompanyIPODetails(Coname);
            if (ls.Count() == 0)
            {
                return NoContent();
            }
            return Ok(ls);
        }

        public IActionResult getCompanyStockPrice(int cid, DateTime dt)
        {
            var ls = repo.getCompanyStockPrice(cid,dt);
            if (ls==null)
            {
                return NoContent();
            }
            return Ok(ls);
        }

        public IActionResult getMatchingCompanies(string Cpattr)
        {

            var ls = repo.getMatchingCompanies(Cpattr);
            return Ok(ls);
        }
    }
}
