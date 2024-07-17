using JobPortal.Data;
using JobPortal.DTO;
using JobPortal.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<GetCityDto>>> Get()
        {
            try
            {
                var cities = await _cityServices.GetAllCitiesAsync();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCityDto>> Get(long id)
        {
            try
            {
                var city = await _cityServices.GetCityByIdAsync(id);
                return Ok(city);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task<ActionResult<GetCityDto>> Post([FromBody] CreateCityDto cityDto)
        {
            try
            {
                var createdCity = await _cityServices.CreateCityAsync(cityDto);
                return CreatedAtAction(nameof(Get), new { id = createdCity.Id }, createdCity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetCityDto>> Put(long id, [FromBody] UpdateCityDto cityDto)
        {
            try
            {
                var updatedCity = await _cityServices.UpdateCityAsync(id, cityDto);
                return Ok(updatedCity);
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
                var deleted = await _cityServices.DeleteCityAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
