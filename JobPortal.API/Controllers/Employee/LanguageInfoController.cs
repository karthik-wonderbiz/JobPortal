using JobPortal.Data;
using JobPortal.IServices;
using JobPortal.IServices.Employee;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.LanguageInfoDto;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageInfoController : ControllerBase
    {
        private readonly ILanguageInfoServices _languageInfoServices;

        public LanguageInfoController(ILanguageInfoServices LanguageInfoServices)
        {
            _languageInfoServices = LanguageInfoServices;
        }

        // GET: api/<LanguageInfoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetLanguageInfoDto>>> Get()
        {
            try
            {
                var languageInfoData = await _languageInfoServices.GetLanguageInfoAsync();
                return Ok(languageInfoData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<LanguageInfoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetLanguageInfoDto>> Get(long id)
        {
            try
            {
                var LanguageInfoData = await _languageInfoServices.GetLanguageInfoById(id);
                return Ok(LanguageInfoData);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/<LanguageInfoController>/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<GetLanguageInfoDto>> GetByUserId(long userId)
        {
            try
            {
                var LanguageInfoData = await _languageInfoServices.GetLanguageInfoByUserId(userId);
                return Ok(LanguageInfoData);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<LanguageInfoController>
        [HttpPost]
        public async Task<ActionResult<GetLanguageInfoDto>> Post([FromBody] CreateLanguageInfoDto LanguageInfoDto)
        {
            try
            {
                var createdLanguageInfo = await _languageInfoServices.CreateLanguageInfoAsync(LanguageInfoDto);
                return Ok(createdLanguageInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<LanguageInfoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetLanguageInfoDto>> Put(long id, [FromBody] UpdateLanguageInfoDto LanguageInfoDto)
        {
            try
            {
                var updatedLanguageInfo = await _languageInfoServices.UpdateLanguageInfoAsync(id, LanguageInfoDto);
                return Ok(updatedLanguageInfo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<LanguageInfoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deletedLanguageInfo = await _languageInfoServices.DeleteLanguageInfoAsync(id);
                return Ok(deletedLanguageInfo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
