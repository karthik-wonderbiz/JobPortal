using JobPortal.DTO;
using JobPortal.IServices;
using JobPortal.IServices.Employee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.WorkExperienceInfoDto;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperienceInfoController : ControllerBase
    {
        private readonly IWorkExperienceInfoServices _workExperienceInfoServices;

        public WorkExperienceInfoController(IWorkExperienceInfoServices locationServices)
        {
            _workExperienceInfoServices = locationServices;
        }

        // GET: api/<WorkExperienceInfoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetWorkExperienceInfoDto>>> Get()
        {
            try
            {
                var workExperienceInfos = await _workExperienceInfoServices.GetWorkExperienceInfosAsync();
                return Ok(workExperienceInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<WorkExperienceInfoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetWorkExperienceInfoDto>> Get(long id)
        {
            try
            {
                var workExperienceInfo = await _workExperienceInfoServices.GetWorkExperienceInfoAsync(id);
                return Ok(workExperienceInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<WorkExperienceInfoController>/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GetWorkExperienceInfoDto>>> GetByUserId(long userId)
        {
            try
            {
                var workExperienceInfo = await _workExperienceInfoServices.GetWorkExperienceInfoByUserId(userId);

                return Ok(workExperienceInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<WorkExperienceInfoController>
        [HttpPost]
        public async Task<ActionResult<GetWorkExperienceInfoDto>> Post([FromBody] CreateWorkExperienceInfoDto locationDto)
        {
            try
            {
                var createdWorkExperienceInfo = await _workExperienceInfoServices.CreateWorkExperienceInfoAsync(locationDto);
                return CreatedAtAction(nameof(Get), new { id = createdWorkExperienceInfo.Id }, createdWorkExperienceInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<WorkExperienceInfoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetWorkExperienceInfoDto>> Put(long id, [FromBody] UpdateWorkExperienceInfoDto locationDto)
        {
            try
            {
                var updatedWorkExperienceInfo = await _workExperienceInfoServices.UpdateWorkExperienceInfoAsync(id, locationDto);
                return Ok(updatedWorkExperienceInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<WorkExperienceInfoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _workExperienceInfoServices.DeleteWorkExperienceInfoAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
