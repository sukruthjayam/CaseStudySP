using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice4.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microservice4.Entities;
using M4Login.Entities;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Microservice4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly IConfiguration Config;
       
        IRepository4 repo;
        public LoginController(IRepository4 repo, IConfiguration config)
        {
            this.repo = repo;
            this.Config = config;
        }

        [HttpGet("{name}/{pass}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult Login(string name,string pass)
        {
           ValidationResponseModel vrm = repo.Login(name, pass);
           
            if (vrm==null)
            {
                return NotFound("user not found"); 
            }
            vrm.JWT = GenerateToken(vrm.usertype,name);
            return Ok(vrm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult getUserbyId(int id)
        {
           UContext vrm = repo.getUser(id);

            if (vrm == null)
            {
                return NotFound("user not found");
            }
           
            return Ok(vrm);
        }

        [HttpPut]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult UpdateProfile(UContext user)
        {
            string upduser = repo.UpdateProfile(user);  
            return Ok(upduser);
        }
        private string GenerateToken(string userType, string username)
        {
            string token = string.Empty;
            var now = DateTime.Now;

            var claims = new Claim[] {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString()),
            new Claim("UserType", userType)
            };

            var KeyText = Config.GetValue<string>("SecurityKey");
            var KeyBytes = Encoding.ASCII.GetBytes(KeyText);
            var Key = new SymmetricSecurityKey(KeyBytes);

            var Jwt = new JwtSecurityToken(claims: claims,
                                           expires: now.AddMinutes(60),
                                           signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256));
            token = new JwtSecurityTokenHandler().WriteToken(Jwt);
           
            return token;
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
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
