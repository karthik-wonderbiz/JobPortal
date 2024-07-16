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
        public async Task<IEnumerable<EmploymentType>> Get()
        {
            return await _empTypeServices.GetEmploymentTypesAsync();
        }

        // GET api/<EmploymentTypeController>/5
        [HttpGet("{id}")]
        public async Task<EmploymentType> Get(int id)
        {
            return await _empTypeServices.GetEmploymentTypeAsync(id);
        }

        // POST api/<EmploymentTypeController>
        [HttpPost]
        public async Task<EmploymentType> Post([FromBody] EmploymentType employmentType)
        {
            return await _empTypeServices.CreateEmploymentTypeAsync(employmentType);
        }

        // PUT api/<EmploymentTypeController>/5
        [HttpPut("{id}")]
        public async Task<EmploymentType> Put(int id, [FromBody] EmploymentType employmentType)
        {
            return await _empTypeServices.UpdateEmploymentTypeAsync(id, employmentType);
        }

        // DELETE api/<EmploymentTypeController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _empTypeServices.DeleteEmploymentTypeAsync(id);
        }
    }
}
