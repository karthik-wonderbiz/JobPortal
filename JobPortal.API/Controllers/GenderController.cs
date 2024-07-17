using JobPortal.DTO;
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
        public async Task<IEnumerable<GetGenderDto>> Get()
        {
            try
            {
                var res = await _genderServices.GetGendersAsync();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<GenderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetGenderDto>> Get(long id)
        {
            try
            {
                var res = await _genderServices.GetGenderAsync(id);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<GenderController>
        [HttpPost]
        public async Task<ActionResult<GetGenderDto>> Post([FromBody] CreateGenderDto genderDto)
        {
            try
            {
                var res = await _genderServices.CreateGenderAsync(genderDto);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<GenderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetGenderDto>> Put(long id, [FromBody] UpdateGenderDto genderDto)
        {
            try
            {
                var res = await _genderServices.UpdateGenderAsync(id, genderDto);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<GenderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var res = await _genderServices.DeleteGenderAsync(id);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
