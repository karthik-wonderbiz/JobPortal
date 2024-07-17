using JobPortal.DTO;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentTypeController : ControllerBase
    {
        private readonly IEmploymentTypeServices _empTypeServices;

        public EmploymentTypeController(IEmploymentTypeServices empTypeServices)
        {
            _empTypeServices = empTypeServices;
        }

        // GET: api/<EmploymentTypeController>
        [HttpGet]
        public async Task<IEnumerable<GetEmploymentTypeDto>> Get()
        {
            try
            {
                var res = await _empTypeServices.GetEmploymentTypesAsync();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<EmploymentTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmploymentTypeDto>> Get(int id)
        {
            try
            {
                var res = await _empTypeServices.GetEmploymentTypeAsync(id);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<EmploymentTypeController>
        [HttpPost]
        public async Task<ActionResult<GetEmploymentTypeDto>> Post([FromBody] CreateEmploymentTypeDto employmentTypeDto)
        {
            try
            {
                var res = await _empTypeServices.CreateEmploymentTypeAsync(employmentTypeDto);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<EmploymentTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetEmploymentTypeDto>> Put(int id, [FromBody] UpdateEmploymentTypeDto employmentTypeDto)
        {
            try
            {
                var res = await _empTypeServices.UpdateEmploymentTypeAsync(id, employmentTypeDto);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<EmploymentTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var res = await _empTypeServices.DeleteEmploymentTypeAsync(id);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
