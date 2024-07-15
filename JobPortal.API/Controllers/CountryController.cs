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
        public async Task<IEnumerable<Country>> Get()
        {
            return await _countryServices.GetAllCountriesAsync();
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public async Task <Country> Get(int id)
        {
            return await _countryServices.GetCountryByIdAsync(id);
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<Country> Post([FromBody] Country country)
        {
            return await _countryServices.CreateCountryAsync(country);
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public async Task<Country> Put(int id, [FromBody] Country country)
        {
            return await _countryServices.UpdateCountryAsync(id, country);
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _countryServices.DeleteCountryAsync(id);
        }
    }
}
