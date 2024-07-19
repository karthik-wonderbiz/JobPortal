using JobPortal.IServices.Employee;
using JobPortal.Services.Employee;
using Microsoft.AspNetCore.Mvc;
using static JobPortal.DTO.Employee.EducationDto;
using static JobPortal.DTO.Employee.SkillInfoDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationServices _educationServices;

        public EducationController(IEducationServices educationServices)
        {
            _educationServices = educationServices;
        }

        // GET: api/<EducationController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetEducationDto>>> Get()
        {
            var education = await _educationServices.GetEducationAsync();
            return Ok(education);
        }

        // GET api/<EducationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEducationDto>> Get(long id)
        {
            try
            {
                var education = await _educationServices.GetEducationAsync(id);
                return Ok(education);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // GET api/<SkillInfoController>/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GetEducationDto>>> GetByUserId(long userId)
        {
            try
            {
                var education = await _educationServices.GetEducationByUserId(userId);

                return Ok(education);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // POST api/<EducationController>
        [HttpPost]
        public async Task<ActionResult<GetEducationDto>> Post([FromBody] CreateEducationDto createEducation)
        {
            try
            {
                var createdSkillInfo = await _educationServices.CreateEducationAsync(createEducation);
                return CreatedAtAction(nameof(Get), new { id = createdSkillInfo.Id }, createdSkillInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<EducationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetEducationDto>> Put(long id, [FromBody] UpdateEducationDto updateEducation)
        {
            try
            {
                var updatedEducation = await _educationServices.UpdateEducationAsync(id, updateEducation);
                return Ok(updatedEducation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<EducationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _educationServices.DeleteEducationAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
