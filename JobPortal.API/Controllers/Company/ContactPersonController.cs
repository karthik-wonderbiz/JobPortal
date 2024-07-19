using JobPortal.Data;
using JobPortal.DTO;
using JobPortal.DTO.Company;
using JobPortal.IServices;
using JobPortal.IServices.Company;
using JobPortal.Services.Company;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static JobPortal.DTO.Company.CompanyInfoDto;

namespace JobPortal.API.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPersonController : ControllerBase
    {
        private readonly IContactPersonServices _contactPersonServices;

        public ContactPersonController(IContactPersonServices contactPersonServices)
        {
            _contactPersonServices = contactPersonServices;
        }

        // GET: api/<ContactPersonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetContactPersonDto>>> Get()
        {
            try
            {
                var res = await _contactPersonServices.GetAllContactPersonAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<ContactPersonController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetContactPersonDto>> Get(long id)
        {
            try
            {
                var res = await _contactPersonServices.GetContactPersonByIdAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<CompanyInfoController>/user/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<GetContactPersonDto>> GetContactPersonByCompanyId(long companyId)
        {
            try
            {
                var contactPerson = await _contactPersonServices.GetContactPersonByCompanyIdAsync(companyId);
                return Ok(contactPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ContactPersonController>
        [HttpPost]
        public async Task<ActionResult<GetContactPersonDto>> Post([FromBody] CreateContactPersonDto contactPersonDto)
        {
            try
            {
                var res = await _contactPersonServices.CreateContactPersonAsync(contactPersonDto);
                return CreatedAtAction(nameof(Get), new { id = res.Id }, res);
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

        // PUT api/<ContactPersonController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetContactPersonDto>> Put(long id, [FromBody] UpdateContactPersonDto contactPersonDto)
        {
            try
            {
                var res = await _contactPersonServices.UpdateContactPersonAsync(id, contactPersonDto);
                return Ok(res);
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

        // DELETE api/<ContactPersonController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var res = await _contactPersonServices.DeleteContactPersonAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
