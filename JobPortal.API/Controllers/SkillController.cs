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
    public class SkillController : ControllerBase
    {
        private readonly ISkillServices _skillServices;

        public SkillController(ISkillServices skillServices)
        {
            _skillServices = skillServices;
        }

        // GET: api/<SkillController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSkillDto>>> Get()
        {
            try
            {
                var skills = await _skillServices.GetSkillsAsync();
                return Ok(skills);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<SkillController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSkillDto>> Get(long id)
        {
            try
            {
                var skill = await _skillServices.GetSkillAsync(id);
                return Ok(skill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<SkillController>
        [HttpPost]
        public async Task<ActionResult<GetSkillDto>> Post([FromBody] CreateSkillDto skillDto)
        {
            try
            {
                var createdSkill = await _skillServices.CreateSkillAsync(skillDto);
                return CreatedAtAction(nameof(Get), new { id = createdSkill.Id }, createdSkill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<SkillController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetSkillDto>> Put(long id, [FromBody] UpdateSkillDto skillDto)
        {
            try
            {
                var updatedSkill = await _skillServices.UpdateSkillAsync(id, skillDto);
                return Ok(updatedSkill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<SkillController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _skillServices.DeleteSkillAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
