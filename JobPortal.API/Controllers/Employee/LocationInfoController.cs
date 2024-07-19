using JobPortal.DTO;
using JobPortal.IServices;
using JobPortal.IServices.Employee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.LocationInfoDto;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationInfoController : ControllerBase
    {
        private readonly ILocationInfoServices _locationInfoServices;

        public LocationInfoController(ILocationInfoServices locationServices)
        {
            _locationInfoServices = locationServices;
        }

        // GET: api/<LocationInfoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetLocationInfoDto>>> Get()
        {
            try
            {
                var locationInfos = await _locationInfoServices.GetLocationInfosAsync();
                return Ok(locationInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<LocationInfoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetLocationInfoDto>> Get(long id)
        {
            try
            {
                var locationInfo = await _locationInfoServices.GetLocationInfoAsync(id);
                return Ok(locationInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<LocationInfoController>/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GetLocationInfoDto>>> GetByUserId(long userId)
        {
            try
            {
                var locationInfo = await _locationInfoServices.GetLocationInfoByUserId(userId);

                return Ok(locationInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<LocationInfoController>
        [HttpPost]
        public async Task<ActionResult<GetLocationInfoDto>> Post([FromBody] CreateLocationInfoDto locationDto)
        {
            try
            {
                var createdLocationInfo = await _locationInfoServices.CreateLocationInfoAsync(locationDto);
                return CreatedAtAction(nameof(Get), new { id = createdLocationInfo.Id }, createdLocationInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<LocationInfoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetLocationInfoDto>> Put(long id, [FromBody] UpdateLocationInfoDto locationDto)
        {
            try
            {
                var updatedLocationInfo = await _locationInfoServices.UpdateLocationInfoAsync(id, locationDto);
                return Ok(updatedLocationInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<LocationInfoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _locationInfoServices.DeleteLocationInfoAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
