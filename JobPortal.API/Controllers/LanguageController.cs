using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IEnumerable<Language>> Get()
        {
            return await _languageServices.GetLanguageAsync();
        }

        // GET api/<LanguageController>/5
        [HttpGet("{id}")]
        public async Task<Language> Get(long id)
        {
            return await _languageServices.GetLanguageById(id);
        }

        // POST api/<LanguageController>
        [HttpPost]
        public async Task<Language> Post([FromBody] Language language)
        {
            return await _languageServices.CreateLanguageAsync(language);
        }

        // PUT api/<LanguageController>/5
        [HttpPut("{id}")]
        public async Task<Language> Put(long id, [FromBody] Language language)
        {
            return await _languageServices.UpdateLanguageAsync(id, language);
        }

        // DELETE api/<LanguageController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            return await _languageServices.DeleteLanguageAsync(id);
        }
    }
}
