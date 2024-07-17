using JobPortal.DTO;
using JobPortal.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static JobPortal.DTO.UrlNameDto;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlNameController : ControllerBase
    {
        private readonly IUrlNameServices _urlNameServices;

        public UrlNameController(IUrlNameServices urlNameServices)
        {
            _urlNameServices = urlNameServices;
        }

        // GET: api/<UrlNameController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUrlNameDto>>> Get()
        {
            try
            {
                var urlNames = await _urlNameServices.GetUrlNameAsync();
                return Ok(urlNames);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<UrlNameController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUrlNameDto>> Get(long id)
        {
            try
            {
                var urlName = await _urlNameServices.GetUrlNameById(id);
                if (urlName == null)
                {
                    return NotFound();
                }
                return Ok(urlName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<UrlNameController>
        [HttpPost]
        public async Task<ActionResult<GetUrlNameDto>> Post([FromBody] CreateUrlNameDto createUrlNameDto)
        {
            try
            {
                var createdUrlName = await _urlNameServices.CreateUrlNameAsync(createUrlNameDto);
                return CreatedAtAction(nameof(Get), new { id = createdUrlName.Id }, createdUrlName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<UrlNameController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetUrlNameDto>> Put(long id, [FromBody] UpdateUrlNameDto updateUrlNameDto)
        {
            try
            {
                var updatedUrlName = await _urlNameServices.UpdateUrlNameAsync(id, updateUrlNameDto);
                return Ok(updatedUrlName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<UrlNameController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _urlNameServices.DeleteUrlNameAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
