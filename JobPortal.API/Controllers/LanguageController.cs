using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;
using static JobPortal.DTO.LanguageDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageServices _languageServices;

        public LanguageController(ILanguageServices languageServices)
        {
            _languageServices = languageServices;
        }

        // GET: api/<LanguageController>
        [HttpGet]
        public async Task<IEnumerable<GetLanguageDto>> Get()
        {
            var res = await _languageServices.GetLanguageAsync();
            return res;
        }

        // GET api/<LanguageController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetLanguageDto>> Get(long id)
        {
            try
            {
                var res = await _languageServices.GetLanguageById(id);
                return res;
            }
            catch (Exception ex)
            {
               return StatusCode(500, ex.Message);   
            }
        }

        // POST api/<LanguageController>
        [HttpPost]
        public async Task<ActionResult<GetLanguageDto>> Post([FromBody] CreateLanguageDto createLanguageDto)
        {
            try
            {
                var res = await _languageServices.CreateLanguageAsync(createLanguageDto);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<LanguageController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetLanguageDto>> Put(long id, [FromBody] UpdateLanguageDto updateLanguageDto)
        {
            try
            {
                var res = await _languageServices.UpdateLanguageAsync(id, updateLanguageDto);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<LanguageController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            var res =  await _languageServices.DeleteLanguageAsync(id);
            return res;
        }
    }
}
