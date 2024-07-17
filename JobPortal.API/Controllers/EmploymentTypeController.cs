using JobPortal.DTO;
using JobPortal.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentTypeController : ControllerBase
    {
        private readonly IEmploymentTypeServices _empTypeServices;

        public EmploymentTypeController(IEmploymentTypeServices empTypeServices)
        {
            _empTypeServices = empTypeServices;
        }

        // GET: api/<EmploymentTypeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetEmploymentTypeDto>>> Get()
        {
            try
            {
                var res = await _empTypeServices.GetEmploymentTypesAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/<EmploymentTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmploymentTypeDto>> Get(long id)
        {
            try
            {
                var res = await _empTypeServices.GetEmploymentTypeAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<EmploymentTypeController>
        [HttpPost]
        public async Task<ActionResult<GetEmploymentTypeDto>> Post([FromBody] CreateEmploymentTypeDto employmentTypeDto)
        {
            try
            {
                var res = await _empTypeServices.CreateEmploymentTypeAsync(employmentTypeDto);
                return CreatedAtAction(nameof(Get), new { id = res.Id }, res);
            }
            catch (Exception ex)
            {
                if (ex.Message == "This input already exists.")
                {
                    return Conflict(ex.Message);
                }
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<EmploymentTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetEmploymentTypeDto>> Put(long id, [FromBody] UpdateEmploymentTypeDto employmentTypeDto)
        {
            try
            {
                var res = await _empTypeServices.UpdateEmploymentTypeAsync(id, employmentTypeDto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                if (ex.Message == "This input already exists.")
                {
                    return Conflict(ex.Message);
                }
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<EmploymentTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var res = await _empTypeServices.DeleteEmploymentTypeAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
