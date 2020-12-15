using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice4.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microservice4.Entities;
namespace Microservice4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        IRepository4 repo;
        public LoginController(IRepository4 repo)
        {
            this.repo = repo;
        }

        [HttpGet("{name}/{pass}")]
        public IActionResult Login(string name,string pass)
        {
            bool bl = repo.Login(name, pass);
            if (bl)
            {
                return Ok("login successful");
            }
            return NotFound("user not found");
        }

        [HttpPost]
        public IActionResult Signup(UContext user) {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);
            var result = repo.UserSignup(user);
            if (!result)
                return BadRequest("Error saving data");
            return Created("No url",new { message="created successfully" });

        }

    }
}
