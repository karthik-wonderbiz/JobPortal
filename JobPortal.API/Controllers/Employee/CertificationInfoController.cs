using JobPortal.DTO;
using JobPortal.IServices;
using JobPortal.IServices.Employee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.CertificationInfoDto;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificationInfoController : ControllerBase
    {
        private readonly ICertificationInfoServices _certificationInfoServices;

        public CertificationInfoController(ICertificationInfoServices locationServices)
        {
            _certificationInfoServices = locationServices;
        }

        // GET: api/<CertificationInfoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCertificationInfoDto>>> Get()
        {
            try
            {
                var certificationInfos = await _certificationInfoServices.GetCertificationInfosAsync();
                return Ok(certificationInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<CertificationInfoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCertificationInfoDto>> Get(long id)
        {
            try
            {
                var certificationInfo = await _certificationInfoServices.GetCertificationInfoAsync(id);
                return Ok(certificationInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<CertificationInfoController>/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GetCertificationInfoDto>>> GetByUserId(long userId)
        {
            try
            {
                var certificationInfo = await _certificationInfoServices.GetCertificationInfoByUserId(userId);

                return Ok(certificationInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<CertificationInfoController>
        [HttpPost]
        public async Task<ActionResult<GetCertificationInfoDto>> Post([FromBody] CreateCertificationInfoDto locationDto)
        {
            try
            {
                var createdCertificationInfo = await _certificationInfoServices.CreateCertificationInfoAsync(locationDto);
                return CreatedAtAction(nameof(Get), new { id = createdCertificationInfo.Id }, createdCertificationInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<CertificationInfoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetCertificationInfoDto>> Put(long id, [FromBody] UpdateCertificationInfoDto locationDto)
        {
            try
            {
                var updatedCertificationInfo = await _certificationInfoServices.UpdateCertificationInfoAsync(id, locationDto);
                return Ok(updatedCertificationInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<CertificationInfoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _certificationInfoServices.DeleteCertificationInfoAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
