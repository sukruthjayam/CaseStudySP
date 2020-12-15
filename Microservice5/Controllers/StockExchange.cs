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
    public class StockExchange : ControllerBase
    {
        IRepository5 repo;
        public StockExchange(IRepository5 repo)
        {
            this.repo = repo;
        }
       
        [HttpGet]
        public IActionResult getSEData()
        {
            var ls = repo.getStockExchangesList();
            if (ls.Count() == 0)
            {
                return NoContent();
            }
            return Ok(ls);
        }

        [HttpGet("{Sname}")]
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
