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
    [Route("api/[controller]")]
    [ApiController]
    public class StockExchangeController : ControllerBase
    {
        IRepository5 repo;
        public StockExchangeController(IRepository5 repo)
        {
            this.repo = repo;
        }
       
        [HttpGet]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult getSEData()
        {
            var ls = repo.getStockExchangesList();
            if (ls.Count() == 0)
            {
                return NotFound();
            }
            return Ok(ls);
        }

        [HttpGet("{Sname}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult getCompData(String Sname)
        {
            var ls = repo.GetCompaniesStock(Sname);
            if (ls.Count() == 0)
            {
                return NotFound();
            }
            return Ok(ls);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public IActionResult addSEdata(SEContext obj)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = repo.addStockExchange(obj);
            if (!result)
                return BadRequest("Error saving products");
            return Created("No Url",new { message="company added"});
            
        }

      
    }

    }
