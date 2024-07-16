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
            return await _countryServices.GetAllCountriesAsync();
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public async Task <GetCountryDto> Get(long id)
        {
            return await _countryServices.GetCountryByIdAsync(id);
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<GetCountryDto> Post([FromBody] CreateCountryDto countryDto)
        {
            return await _countryServices.CreateCountryAsync(countryDto);
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public async Task<GetCountryDto> Put(long id, [FromBody] UpdateCountryDto countryDto)
        {
            return await _countryServices.UpdateCountryAsync(id, countryDto);
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            return await _countryServices.DeleteCountryAsync(id);
        }
    }
}
