using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice3.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorStockPriceController : ControllerBase
    {

        IRepository3 repo;
        public SectorStockPriceController(IRepository3 repo)
        {
            this.repo = repo;
        }

        [HttpGet("{Sname}")]
        public IActionResult getSectorPrice(string Sname)
        {
            var ls = repo.getSectorPrice(Sname);
            return Ok(ls);
        }
    }
}
