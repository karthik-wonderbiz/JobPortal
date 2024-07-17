using JobPortal.Data;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityServices _cityServices;

        public CityController(ICityServices cityServices)
        {
            _cityServices = cityServices;
        }

        // GET: api/<CityController>
        [HttpGet]
        public async Task<IEnumerable<GetCityDto>> Get()
        {
            try
            {
                var getAllCityObject = await _cityServices.GetAllCitiesAsync();
                return getAllCityObject;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCityDto>> Get(long id)
        {
            try
            {
                var getCityObject = await _cityServices.GetCityByIdAsync(id);
                return getCityObject;
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task<GetCityDto> Post([FromBody] CreateCityDto cityDto)
        {
            try
            {
                var createCityObject = await _cityServices.CreateCityAsync(cityDto);
                return createCityObject;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetCityDto>> Put(long id, [FromBody] UpdateCityDto cityDto)
        {
            try
            {
                var updateCityObject = await _cityServices.UpdateCityAsync(id, cityDto);
                return updateCityObject;
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleteCityObject = await _cityServices.DeleteCityAsync(id);
                return deleteCityObject;
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
