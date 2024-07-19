using JobPortal.IServices.Employee;
using JobPortal.Services.Employee;
using Microsoft.AspNetCore.Mvc;
using static JobPortal.DTO.Employee.ProjectDto;
using static JobPortal.DTO.Employee.SkillInfoDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectServices _projectServices;
        public ProjectController(IProjectServices projectServices)
        {
            _projectServices = projectServices;
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProjectDto>>> Get()
        {
            try
            {
                var projectInfo = await _projectServices.GetProjectsAsync();
                return Ok(projectInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProjectDto>> Get(long id)
        {
            try
            {
                var projectInfo = await _projectServices.GetProjectAsync(id);
                return Ok(projectInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<SkillInfoController>/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GetProjectDto>>> GetByUserId(long userId)
        {
            try
            {
                var projectInfo = await _projectServices.GetProjectByUserId(userId);
                return Ok(projectInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ProjectController>
        [HttpPost]
        public async Task<ActionResult<GetProjectDto>> Post([FromBody] CreateProjectDto createProjectDto)
        {
            try
            {
                var projectInfo = await _projectServices.CreateProjectAsync(createProjectDto);
                return CreatedAtAction(nameof(Get), new { id = projectInfo.Id }, createProjectDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetProjectDto>> Put(long id, [FromBody] UpdateProjectDto updateProjectDto)
        {
            try
            {
                var updateInfo = await _projectServices.UpdateProjectAsync(id, updateProjectDto);
                return Ok(updateInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _projectServices.DeleteProjectAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
