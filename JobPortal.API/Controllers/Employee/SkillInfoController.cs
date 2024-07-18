using JobPortal.DTO;
using JobPortal.IServices;
using JobPortal.IServices.Employee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.SkillInfoDto;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillInfoController : ControllerBase
    {
        private readonly ISkillInfoServices _skillInfoServices;

        public SkillInfoController(ISkillInfoServices skillServices)
        {
            _skillInfoServices = skillServices;
        }

        // GET: api/<SkillInfoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSkillInfoDto>>> Get()
        {
            try
            {
                var skillInfos = await _skillInfoServices.GetSkillInfosAsync();
                return Ok(skillInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<SkillInfoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSkillInfoDto>> Get(long id)
        {
            try
            {
                var skillInfo = await _skillInfoServices.GetSkillInfoAsync(id);
                return Ok(skillInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<SkillInfoController>/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GetSkillInfoDto>>> GetByUserId(long userId)
        {
            try
            {
                var skillInfo = await _skillInfoServices.GetSkillInfoByUserId(userId);

                return Ok(skillInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<SkillInfoController>
        [HttpPost]
        public async Task<ActionResult<GetSkillInfoDto>> Post([FromBody] CreateSkillInfoDto skillDto)
        {
            try
            {
                var createdSkillInfo = await _skillInfoServices.CreateSkillInfoAsync(skillDto);
                return CreatedAtAction(nameof(Get), new { id = createdSkillInfo.Id }, createdSkillInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<SkillInfoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetSkillInfoDto>> Put(long id, [FromBody] UpdateSkillInfoDto skillDto)
        {
            try
            {
                var updatedSkillInfo = await _skillInfoServices.UpdateSkillInfoAsync(id, skillDto);
                return Ok(updatedSkillInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<SkillInfoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _skillInfoServices.DeleteSkillInfoAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
