using JobPortal.IServices;
using Microsoft.AspNetCore.Mvc;
using static JobPortal.DTO.LanguageDto;

[Route("api/[controller]")]
[ApiController]
public class LanguageController : ControllerBase
{
    private readonly ILanguageServices _languageServices;

    public LanguageController(ILanguageServices languageServices)
    {
        _languageServices = languageServices;
    }

    // GET: api/language
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetLanguageDto>>> GetAll()
    {
        try
        {
            var res = await _languageServices.GetLanguageAsync();
            return Ok(res);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET api/language/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetLanguageDto>> GetById(long id)
    {
        try
        {
            var res = await _languageServices.GetLanguageById(id);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // POST api/language
    [HttpPost]
    public async Task<ActionResult<GetLanguageDto>> Post([FromBody] CreateLanguageDto createLanguageDto)
    {
        try
        {
            var res = await _languageServices.CreateLanguageAsync(createLanguageDto);
            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
        }
        catch (Exception ex)
        {
            if (ex.Message == "This input already exists.")
            {
                return Conflict(ex.Message);
            }
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // PUT api/language/5
    [HttpPut("{id}")]
    public async Task<ActionResult<GetLanguageDto>> Put(long id, [FromBody] UpdateLanguageDto updateLanguageDto)
    {
        try
        {
            var res = await _languageServices.UpdateLanguageAsync(id, updateLanguageDto);
            return Ok(res);
        }
        catch (Exception ex)
        {
            if (ex.Message == "This input already exists.")
            {
                return Conflict(ex.Message);
            }
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE api/language/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(long id)
    {
        try
        {
            var res = await _languageServices.DeleteLanguageAsync(id);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
