using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microservice2.Entities;
namespace Microservice2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPOController : ControllerBase
    {
        IRepository2 repo;
        public IPOController(IRepository2 repo)
        {
            this.repo = repo;
        }
       
        [HttpGet("{coname}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult getcompanyipodetails(string coname)
        {
            var ls = repo.getCompanyIPODetails(coname);
            if (ls == null)
            {
                return NotFound();
            }
            return Ok(ls);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public IActionResult UpdateIPO(IPOContext ipo)
        {
            var ls = repo.UpdateIPO(ipo);
            
            return Ok("successfully updated");
        }
    }
}
