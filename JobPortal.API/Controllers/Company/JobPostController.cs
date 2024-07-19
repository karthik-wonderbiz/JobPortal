using JobPortal.DTO.Company;
using JobPortal.IServices.Company;
using JobPortal.IServices.Employee;
using JobPortal.Services.Employee;
using Microsoft.AspNetCore.Mvc;
using static JobPortal.DTO.Employee.LocationInfoDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController : ControllerBase
    {
        private readonly IJobPostServices _jobPostServices;
        public JobPostController(IJobPostServices jobPostServices)
        {
            _jobPostServices = jobPostServices;
        }
        // GET: api/<JobPostController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetJobPostDto>>> Get()
        {
            try
            {
                var jobPostInfo = await _jobPostServices.GetAllJobPostsAsync();
                return Ok(jobPostInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<JobPostController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetJobPostDto>> Get(long id)
        {
            try
            {
                var jobPostInfo = await _jobPostServices.GetJobPostByIdAsync(id);
                return Ok(jobPostInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<JobPostController>
        [HttpPost]
        public async Task<ActionResult<GetJobPostDto>> Post([FromBody] CreateJobPostDto jobPostDto)
        {
            try
            {
                var createdJobPost = await _jobPostServices.CreateJobPostAsync(jobPostDto);
                return CreatedAtAction(nameof(Get), new { id = createdJobPost.Id }, createdJobPost);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<JobPostController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetJobPostDto>> Put(long id, [FromBody] UpdateJobPostDto jobPostDto)
        {
            try
            {
                var updatedJobPost = await _jobPostServices.UpdateJobPostAsync(id, jobPostDto);
                return Ok(updatedJobPost);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<JobPostController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _jobPostServices.DeleteJobPostAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<LocationInfoController>/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GetJobPostDto>>> GetLocationInfoByUserId(long userId)
        {
            try
            {
                var jobPostInfo = await _jobPostServices.GetJobPostByIdAsync(userId);

                return Ok(jobPostInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
