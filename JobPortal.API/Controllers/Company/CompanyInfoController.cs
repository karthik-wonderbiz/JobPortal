using JobPortal.Data;
using JobPortal.DTO.Company;
using JobPortal.IServices;
using JobPortal.IServices.Company;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.API.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyInfoController : ControllerBase
    {
        private readonly ICompanyInfoServices _companyInfoServices;

        public CompanyInfoController(ICompanyInfoServices companyInfoServices)
        {
            _companyInfoServices = companyInfoServices;
        }

        // GET: api/<CompanyInfoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCompanyInfoDto>>> Get()
        {
            try
            {
                var companies = await _companyInfoServices.GetAllCompaniesAsync();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<CompanyInfoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCompanyInfoDto>> Get(long id)
        {
            try
            {
                var companyInfo = await _companyInfoServices.GetCompanyInfoByIdAsync(id);
                return Ok(companyInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<CompanyInfoController>/user/5
        [HttpGet("user/{Id}")]
        public async Task<ActionResult<GetCompanyInfoDto>> GetByUser(long UserId)
        {
            try
            {
                var companyInfo = await _companyInfoServices.GetCompanyInfoByUserIdAsync(UserId);
                return Ok(companyInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<CompanyInfoController>
        [HttpPost]
        public async Task<ActionResult<GetCompanyInfoDto>> Post([FromBody] CreateCompanyInfoDto companyInfoDto)
        {
            try
            {
                var createdCompanyInfo = await _companyInfoServices.CreateCompanyInfoAsync(companyInfoDto);
                return CreatedAtAction(nameof(Get), new { id = createdCompanyInfo.Id }, createdCompanyInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<CompanyInfoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetCompanyInfoDto>> Put(long id, [FromBody] UpdateCompanyInfoDto companyInfoDto)
        {
            try
            {
                var updatedCompanyInfo = await _companyInfoServices.UpdateCompanyInfoAsync(id, companyInfoDto);
                return Ok(updatedCompanyInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<CompanyInfoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _companyInfoServices.DeleteCompanyInfoAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
