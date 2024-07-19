using JobPortal.Data;
using JobPortal.IServices;
using JobPortal.IServices.Employee;
using JobPortal.Model;
using JobPortal.Services.Employee;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.SkillInfoDto;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly IPublicationServices _publicationServices;

        public PublicationController(IPublicationServices PublicationServices)
        {
            _publicationServices = PublicationServices;
        }

        // GET: api/<PublicationController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPublicationDto>>> Get()
        {
            try
            {
                var publicationData = await _publicationServices.GetAllPublicationsAsync();
                return Ok(publicationData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<PublicationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPublicationDto>> Get(long id)
        {
            try
            {
                var PublicationData = await _publicationServices.GetPublicationByIdAsync(id);
                return Ok(PublicationData);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<PublicationController>
        [HttpPost]
        public async Task<ActionResult<GetPublicationDto>> Post([FromBody] CreatePublicationDto PublicationDto)
        {
            try
            {
                var createdPublication = await _publicationServices.CreatePublicationAsync(PublicationDto);
                return Ok(createdPublication);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<PublicationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetPublicationDto>> Put(long id, [FromBody] UpdatePublicationDto PublicationDto)
        {
            try
            {
                var updatedPublication = await _publicationServices.UpdatePublicationAsync(id, PublicationDto);
                return Ok(updatedPublication);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<PublicationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deletedPublication = await _publicationServices.DeletePublicationAsync(id);
                return Ok(deletedPublication);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/<SkillInfoController>/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GetSkillInfoDto>>> GetByUserId(long userId)
        {
            try
            {
                var publication = await _publicationServices.GetPublicationByUserId(userId);

                return Ok(publication);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
