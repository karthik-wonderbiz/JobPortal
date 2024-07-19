using JobPortal.DTO;
using JobPortal.IServices;
using JobPortal.IServices.Employee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.UrlInfoDto;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlInfoController : ControllerBase
    {
        private readonly IUrlInfoServices _urlInfoServices;

        public UrlInfoController(IUrlInfoServices urlServices)
        {
            _urlInfoServices = urlServices;
        }

        // GET: api/<UrlInfoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUrlInfoDto>>> Get()
        {
            try
            {
                var urlInfos = await _urlInfoServices.GetUrlInfosAsync();
                return Ok(urlInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<UrlInfoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUrlInfoDto>> Get(long id)
        {
            try
            {
                var urlInfo = await _urlInfoServices.GetUrlInfoAsync(id);
                return Ok(urlInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<UrlInfoController>/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GetUrlInfoDto>>> GetByUserId(long userId)
        {
            try
            {
                var urlInfo = await _urlInfoServices.GetUrlInfoByUserId(userId);

                return Ok(urlInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<UrlInfoController>
        [HttpPost]
        public async Task<ActionResult<GetUrlInfoDto>> Post([FromBody] CreateUrlInfoDto urlDto)
        {
            try
            {
                var createdUrlInfo = await _urlInfoServices.CreateUrlInfoAsync(urlDto);
                return CreatedAtAction(nameof(Get), new { id = createdUrlInfo.Id }, createdUrlInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<UrlInfoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetUrlInfoDto>> Put(long id, [FromBody] UpdateUrlInfoDto urlDto)
        {
            try
            {
                var updatedUrlInfo = await _urlInfoServices.UpdateUrlInfoAsync(id, urlDto);
                return Ok(updatedUrlInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<UrlInfoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _urlInfoServices.DeleteUrlInfoAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
