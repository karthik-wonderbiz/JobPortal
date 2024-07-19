using JobPortal.Data;
using JobPortal.DTO;
using JobPortal.DTO.Company;
using JobPortal.IServices;
using JobPortal.IServices.Company;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.ProjectDto;

namespace JobPortal.API.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterServices _recruiterServices;

        public RecruiterController(IRecruiterServices recruiterServices)
        {
            _recruiterServices = recruiterServices;
        }

        // GET: api/<RecruiterController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetRecruiterDto>>> Get()
        {
            try
            {
                var res = await _recruiterServices.GetAllRecruiterAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<RecruiterController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRecruiterDto>> Get(long id)
        {
            try
            {
                var res = await _recruiterServices.GetRecruiterByIdAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<RecruiterController>/user/1
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GetRecruiterDto>>> GetRecruiterByCompanyId(long userId)
        {
            try
            {
                var recruiters = await _recruiterServices.GetRecruiterByCompanyId(userId);
                return Ok(recruiters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<RecruiterController>
        [HttpPost]
        public async Task<ActionResult<GetRecruiterDto>> Post([FromBody] CreateRecruiterDto recruiterDto)
        {
            try
            {
                var res = await _recruiterServices.CreateRecruiterAsync(recruiterDto);
                return CreatedAtAction(nameof(Get), new { id = res.Id }, res);
            }
            catch (Exception ex)
            {
                if (ex.Message == "This input already exists.")
                {
                    return Conflict(ex.Message);
                }
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<RecruiterController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetRecruiterDto>> Put(long id, [FromBody] UpdateRecruiterDto recruiterDto)
        {
            try
            {
                var res = await _recruiterServices.UpdateRecruiterAsync(id, recruiterDto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                if (ex.Message == "This input already exists.")
                {
                    return Conflict(ex.Message);
                }
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<RecruiterController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var res = await _recruiterServices.DeleteRecruiterAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
