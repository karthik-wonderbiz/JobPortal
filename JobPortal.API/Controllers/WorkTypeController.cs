using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;
using static JobPortal.DTO.WorkTypeDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTypeController : ControllerBase
    {
        private readonly IWorkTypeServices _workTypeServices;

        public WorkTypeController(IWorkTypeServices workTypeServices)
        {
            _workTypeServices = workTypeServices;
        }

        // GET: api/<WorkTypeController>
        [HttpGet]
        public async Task<IEnumerable<GetWorkTypeDto>> Get()
        {
            var res = await _workTypeServices.GetWorkTypeAsync();
            return res;
        }

        // GET api/<WorkTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetWorkTypeDto>> Get(long id)
        {
            try
            {
                var res = await _workTypeServices.GetWorkTypeById(id);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<WorkTypeController>
        [HttpPost]
        public async Task<ActionResult<GetWorkTypeDto>> Post([FromBody] CreateWorkTypeDto createWorkTypeDto)
        {
            try
            {
                var res = await _workTypeServices.CreateWorkTypeAsync(createWorkTypeDto);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<WorkTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetWorkTypeDto>> Put(long id, [FromBody] UpdateWorkTypeDto updateWorkTypeDto)
        {
            try
            {
                var res = await _workTypeServices.UpdateWorkTypeAsync(id, updateWorkTypeDto);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<WorkTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var res = await _workTypeServices.DeleteWorkTypeAsync(id);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
