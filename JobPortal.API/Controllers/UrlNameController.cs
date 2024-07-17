using JobPortal.IServices;
using JobPortal.Services;
using Microsoft.AspNetCore.Mvc;
using static JobPortal.DTO.LanguageDto;
using static JobPortal.DTO.UrlNameDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IEnumerable<GetUrlNameDto>> Get()
        {
            var res = await _urlNameServices.GetUrlNameAsync();
            return res;
        }

        // GET api/<UrlNameController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUrlNameDto>> Get(long id)
        {
            try
            {
                var res = await _urlNameServices.GetUrlNameById(id);
                return res;
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
                var res = await _urlNameServices.CreateUrlNameAsync(createUrlNameDto);
                return res;
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
                var res = await _urlNameServices.UpdateUrlNameAsync(id, updateUrlNameDto);
                return res;
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
            var res = await _urlNameServices.DeleteUrlNameAsync(id);
            return res;
        }
    }
}
