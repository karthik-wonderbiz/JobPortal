using JobPortal.Data;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> Get()
        {
            try
            {
                var countriesData = await _countryServices.GetAllCountriesAsync();
                return Ok(countriesData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountryDto>> Get(long id)
        {
            try
            {
                var countryData = await _countryServices.GetCountryByIdAsync(id);
                return Ok(countryData);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<ActionResult<GetCountryDto>> Post([FromBody] CreateCountryDto countryDto)
        {
            try
            {
                var createdCountry = await _countryServices.CreateCountryAsync(countryDto);
                return CreatedAtAction(nameof(Get), new { id = createdCountry.Id }, createdCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message == "This input already exists.")
                {
                    return Conflict(ex.Message);
                }
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetCountryDto>> Put(long id, [FromBody] UpdateCountryDto countryDto)
        {
            try
            {
                var updatedCountry = await _countryServices.UpdateCountryAsync(id, countryDto);
                return Ok(updatedCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message == "This input already exists.")
                {
                    return Conflict(ex.Message);
                }
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
                return Ok(deletedCountry);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
