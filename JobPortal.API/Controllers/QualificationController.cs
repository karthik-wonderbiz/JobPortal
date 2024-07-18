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
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationServices _qualificationServices;

        public QualificationController(IQualificationServices qualificationServices)
        {
            _qualificationServices = qualificationServices;
        }

        // GET: api/<QualificationController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetQualificationDto>>> Get()
        {
            try
            {
                var res = await _qualificationServices.GetQualificationsAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<QualificationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetQualificationDto>> Get(long id)
        {
            try
            {
                var res = await _qualificationServices.GetQualificationAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<QualificationController>
        [HttpPost]
        public async Task<ActionResult<GetQualificationDto>> Post([FromBody] CreateQualificationDto qualificationDto)
        {
            try
            {
                var res = await _qualificationServices.CreateQualificationAsync(qualificationDto);
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

        // PUT api/<QualificationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetQualificationDto>> Put(long id, [FromBody] UpdateQualificationDto qualificationDto)
        {
            try
            {
                var res = await _qualificationServices.UpdateQualificationAsync(id, qualificationDto);
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

        // DELETE api/<QualificationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var res = await _qualificationServices.DeleteQualificationAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
