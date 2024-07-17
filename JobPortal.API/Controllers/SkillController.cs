using JobPortal.DTO;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IEnumerable<GetSkillDto>> Get()
        {
            try
            {
                var res = await _skillServices.GetSkillsAsync();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<SkillController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSkillDto>> Get(long id)
        {
            try
            {
                var res = await _skillServices.GetSkillAsync(id);
                return res;
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
                var res = await _skillServices.CreateSkillAsync(skillDto);
                return res;
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
                var res = await _skillServices.UpdateSkillAsync(id, skillDto);
                return res;
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
                var res = await _skillServices.DeleteSkillAsync(id);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
