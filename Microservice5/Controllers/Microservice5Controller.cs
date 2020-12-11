using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microservice5.Repository;
using Microservice5.Entities;

namespace Microservice5.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Microservice5Controller : ControllerBase
    {
        IRepository5 repo;
        public Microservice5Controller(IRepository5 repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(404)]
        public IActionResult getSEData()
        {
            var ls = repo.getStockExchangesList();
            if (ls.Count() == 0)
            {
                return NoContent();
            }
            return Ok(ls);
        }

        [HttpGet]
        [ProducesResponseType(404)]
        public IActionResult getCompData(String Sname)
        {
            var ls = repo.GetCompaniesStock(Sname);
            if (ls.Count() == 0)
            {
                return NoContent();
            }
            return Ok(ls);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult addSEdata(SEContext obj)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = repo.addStockExchange(obj);
            if (!result)
                return BadRequest("Error saving products");
            return StatusCode(201);
            
        }

      
    }

    }
