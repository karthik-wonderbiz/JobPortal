using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderServices _genderServices;

        public GenderController(IGenderServices genderServices)
        {
            _genderServices = genderServices;
        }

        // GET: api/<GenderController>
        [HttpGet]
        public async Task<IEnumerable<Gender>> Get()
        {
            return await _genderServices.GetGendersAsync();
        }

        // GET api/<GenderController>/5
        [HttpGet("{id}")]
        public async Task<Gender> Get(int id)
        {
            return await _genderServices.GetGenderAsync(id);
        }

        // POST api/<GenderController>
        [HttpPost]
        public async Task<Gender> Post([FromBody] Gender gender)
        {
            return await _genderServices.CreateGenderAsync(gender);
        }

        // PUT api/<GenderController>/5
        [HttpPut("{id}")]
        public async Task<Gender> Put(int id, [FromBody] Gender gender)
        {
            return await _genderServices.UpdateGenderAsync(id, gender);
        }

        // DELETE api/<GenderController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _genderServices.DeleteGenderAsync(id);
        }
    }
}
