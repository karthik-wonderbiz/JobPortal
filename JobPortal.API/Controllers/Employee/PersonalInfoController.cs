using JobPortal.IServices.Employee;
using JobPortal.Services.Employee;
using Microsoft.AspNetCore.Mvc;
using static JobPortal.DTO.Employee.PersonalInfoDto;
using static JobPortal.DTO.Employee.SkillInfoDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private readonly IPersonalInfoServices _personalInfoServices;

        public PersonalInfoController(IPersonalInfoServices personalInfoServices)
        {
            _personalInfoServices = personalInfoServices;
        }

        // GET: api/<PersonalInfoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPersonalInfoDto>>> Get()
        {
            try
            {
                var personalInfos = await _personalInfoServices.GetPersonalInfosAsync();
                return Ok(personalInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<PersonalInfoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPersonalInfoDto>> Get(long id)
        {
            try
            {
                var personalInfo = await _personalInfoServices.GetPersonalInfoAsync(id);
                return Ok(personalInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<SkillInfoController>/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GetPersonalInfoDto>>> GetByUserId(long userId)
        {
            try
            {
                var personalInfo = await _personalInfoServices.GetPersonalInfoByUserId(userId);

                return Ok(personalInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<PersonalInfoController>
        [HttpPost]
        public async Task<ActionResult<GetPersonalInfoDto>> Post([FromBody] CreatePersonalInfoDto createPersonalInfoDto)
        {
            try
            {
                var createdPersonalInfo = await _personalInfoServices.CreatePersonalInfoAsync(createPersonalInfoDto);
                return CreatedAtAction(nameof(Get), new { id = createdPersonalInfo.Id }, createdPersonalInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<PersonalInfoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetPersonalInfoDto>> Put(long id, [FromBody] UpdatePersonalInfoDto updatePersonalInfoDto)
        {
            try
            {
                var updatedPersonalInfo = await _personalInfoServices.UpdatePersonalInfoAsync(id, updatePersonalInfoDto);
                return Ok(updatedPersonalInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<PersonalInfoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _personalInfoServices.DeletePersonalInfoAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
