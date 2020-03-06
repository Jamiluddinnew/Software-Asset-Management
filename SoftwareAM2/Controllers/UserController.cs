using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareAm2.Repos.Interface;
using SoftwareAM2.data.Models;

namespace SoftwareAM2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> repository;

        public UserController(IRepository<User> _repository)
        {
            repository = _repository;
        }

        // GET api/User
        [HttpGet]
        public IActionResult Get()
        {
            var user = repository.GetAll();
            return Ok(user);
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = repository.GetbyId(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        // POST api/User
        [HttpPost]
        public void Post([FromBody] User value)
        {
            if (value is null)
            {
                BadRequest("User is null.");
            }

            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            repository.Add(value);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User value)
        {
            if (value == null)
            {
                return BadRequest("User is null.");
            }

            User user = repository.GetbyId(id);
            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            repository.Update(user, value);
            return NoContent();
        }

    }
}