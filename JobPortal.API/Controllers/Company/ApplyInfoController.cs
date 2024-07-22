using JobPortal.IServices.Company;
using JobPortal.IServices.Employee;
using Microsoft.AspNetCore.Mvc;
using static JobPortal.DTO.Company.ApplyInfoDto;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyInfoController : ControllerBase
    {
        private readonly IApplyInfoServices _applyInfoServices;

        public ApplyInfoController(IApplyInfoServices ApplyInfoServices)
        {
            _applyInfoServices = ApplyInfoServices;
        }

        // GET: api/<ApplyInfoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetApplyInfoDto>>> Get()
        {
            try
            {
                var applyInfoData = await _applyInfoServices.GetApplyInfoAsync();
                return Ok(applyInfoData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<ApplyInfoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetApplyInfoDto>> Get(long id)
        {
            try
            {
                var ApplyInfoData = await _applyInfoServices.GetApplyInfoById(id);
                return Ok(ApplyInfoData);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/<ApplyInfoController>/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<GetApplyInfoDto>> GetByUserId(long userId)
        {
            try
            {
                var ApplyInfoData = await _applyInfoServices.GetApplyInfoByUserId(userId);
                return Ok(ApplyInfoData);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<ApplyInfoController>
        [HttpPost]
        public async Task<ActionResult<GetApplyInfoDto>> Post([FromBody] CreateApplyInfoDto ApplyInfoDto)
        {
            try
            {
                var createdApplyInfo = await _applyInfoServices.CreateApplyInfoAsync(ApplyInfoDto);
                return Ok(createdApplyInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<ApplyInfoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetApplyInfoDto>> Put(long id, [FromBody] UpdateApplyInfoDto ApplyInfoDto)
        {
            try
            {
                var updatedApplyInfo = await _applyInfoServices.UpdateApplyInfoAsync(id, ApplyInfoDto);
                return Ok(updatedApplyInfo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<ApplyInfoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deletedApplyInfo = await _applyInfoServices.DeleteApplyInfoAsync(id);
                return Ok(deletedApplyInfo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
