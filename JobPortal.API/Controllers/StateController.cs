using JobPortal.Data;
using JobPortal.DTO;
using JobPortal.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateServices _stateServices;

        public StateController(IStateServices stateServices)
        {
            _stateServices = stateServices;
        }

        // GET: api/<StateController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetStateDto>>> Get()
        {
            try
            {
                var res = await _stateServices.GetAllStatesAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<StateController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetStateDto>> Get(long id)
        {
            try
            {
                var res = await _stateServices.GetStateByIdAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<StateController>
        [HttpPost]
        public async Task<ActionResult<GetStateDto>> Post([FromBody] CreateStateDto stateDto)
        {
            try
            {
                var res = await _stateServices.CreateStateAsync(stateDto);
                return CreatedAtAction(nameof(Get), new { id = res.Id }, res);
            }
            catch (Exception ex)
            {
                if (ex.Message == "This input already exists.")
                {
                    return Conflict(ex.Message);
                }
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<StateController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetStateDto>> Put(long id, [FromBody] UpdateStateDto stateDto)
        {
            try
            {
                var res = await _stateServices.UpdateStateAsync(id, stateDto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                if (ex.Message == "This input already exists.")
                {
                    return Conflict(ex.Message);
                }
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<StateController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var res = await _stateServices.DeleteStateAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
