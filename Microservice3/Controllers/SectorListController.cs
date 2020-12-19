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
    public class SectorListController : ControllerBase
    {
        IRepository3 repo;
        public SectorListController(IRepository3 repo)
        {
            this.repo = repo;
        }

        [HttpGet("{Secname}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult getList(string Secname)
        {
            var ls = repo.getList(Secname);
            if (ls.Count() == 0)
            {
                return NotFound();
            }
            return Ok(ls);
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult getAllSectors()
        {
            var ls = repo.getAllSectors();
            if (ls.Count() == 0)
            {
                return NotFound();
            }
            return Ok(ls);
        }

    }


}
