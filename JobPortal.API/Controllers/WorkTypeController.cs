using JobPortal.DTO;
using JobPortal.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static JobPortal.DTO.WorkTypeDto;

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

        // GET: api/worktype
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetWorkTypeDto>>> GetAllWorkTypes()
        {
            try
            {
                var workTypes = await _workTypeServices.GetWorkTypeAsync();
                return Ok(workTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/worktype/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetWorkTypeDto>> GetWorkTypeById(long id)
        {
            try
            {
                var workType = await _workTypeServices.GetWorkTypeById(id);
                return Ok(workType);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/worktype
        [HttpPost]
        public async Task<ActionResult<GetWorkTypeDto>> CreateWorkType([FromBody] CreateWorkTypeDto createWorkTypeDto)
        {
            try
            {
                var createdWorkType = await _workTypeServices.CreateWorkTypeAsync(createWorkTypeDto);
                return CreatedAtAction(nameof(GetWorkTypeById), new { id = createdWorkType.Id }, createdWorkType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/worktype/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetWorkTypeDto>> UpdateWorkType(long id, [FromBody] UpdateWorkTypeDto updateWorkTypeDto)
        {
            try
            {
                var updatedWorkType = await _workTypeServices.UpdateWorkTypeAsync(id, updateWorkTypeDto);
                return Ok(updatedWorkType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/worktype/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteWorkType(long id)
        {
            try
            {
                var deleted = await _workTypeServices.DeleteWorkTypeAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
