using JobPortal.Data;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryServices _countryServices;

        public CountryController(ICountryServices countryServices)
        {
            _countryServices = countryServices;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public async Task<IEnumerable<GetCountryDto>> Get()
        {
            var countriesData = await _countryServices.GetAllCountriesAsync();
            return countriesData;
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public async Task <ActionResult<GetCountryDto>>  Get(long id)
        {
            try
            {
                var countryData = await _countryServices.GetCountryByIdAsync(id);
                return countryData;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<GetCountryDto> Post([FromBody] CreateCountryDto countryDto)
        {
            var createdCountry = await _countryServices.CreateCountryAsync(countryDto);
            return createdCountry;
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public async Task <ActionResult<GetCountryDto>>  Put(long id, [FromBody] UpdateCountryDto countryDto)
        {
            try
            {
                var updatedCountry = await _countryServices.UpdateCountryAsync(id, countryDto);
                return updatedCountry;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deletedCountry = await _countryServices.DeleteCountryAsync(id);
                return deletedCountry;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
