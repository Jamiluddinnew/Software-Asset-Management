using System;
using System.Collections.Generic;
//using System.ComponentModel;
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
    public class LicenseController : ControllerBase
    {
        private readonly IRepository<License> repository;
        private readonly TestDB2Context context;

        public LicenseController(IRepository<License> _repository, TestDB2Context _context)
        {
            repository = _repository;
            context = _context;
        }
        // GET: api/License
        [HttpGet]
        public IActionResult Get()
        {
            var user = repository.GetAll();
            return Ok(user);
        }

        // GET: api/License/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var user = repository.GetAll();
            return Ok(user);
        }

        // POST: api/License
        [HttpPost]
        public void Post([FromBody] License value)
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

        // PUT: api/License/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] License value)
        {
            if (value == null)
            {
                return BadRequest("License is null.");
            }

            License license = repository.GetbyId(id);
            if (license == null)
            {
                return NotFound("The License record couldn't be found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            repository.Update(license, value);
            return NoContent();
        }

        // PUT: api/License/5
        [HttpPut("{id}/renew")]
        public IActionResult Putrenew(int id, [FromBody] License value)
        {
            License license = context.License.Where(e => e.Organization.Id == id).FirstOrDefault();
            if (license == null)
               return NotFound();
            license.LisenseEnd = value.LisenseEnd;
            context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
