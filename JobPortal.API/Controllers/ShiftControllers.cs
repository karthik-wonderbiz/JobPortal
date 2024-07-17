using JobPortal.Data;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftServices _shiftServices;

        public ShiftController(IShiftServices shiftServices)
        {
            _shiftServices = shiftServices;
        }

        // GET: api/<ShiftController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetShiftDto>>> Get()
        {
            try
            {
                var getAllShiftObject = await _shiftServices.GetAllShiftsAsync();
                return Ok(getAllShiftObject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<ShiftController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetShiftDto>> Get(long id)
        {
            try
            {
                var getShiftObject = await _shiftServices.GetShiftByIdAsync(id);
                return Ok(getShiftObject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ShiftController>
        [HttpPost]
        public async Task<ActionResult<GetShiftDto>> Post([FromBody] CreateShiftDto shiftDto)
        {
            try
            {
                var createShiftObject = await _shiftServices.CreateShiftAsync(shiftDto);
                return CreatedAtAction(nameof(Get), new { id = createShiftObject.Id }, createShiftObject);
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

        // PUT api/<ShiftController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetShiftDto>> Put(long id, [FromBody] UpdateShiftDto shiftDto)
        {
            try
            {
                var updateShiftObject = await _shiftServices.UpdateShiftAsync(id, shiftDto);
                return Ok(updateShiftObject);
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

        // DELETE api/<ShiftController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleteShiftObject = await _shiftServices.DeleteShiftAsync(id);
                return Ok(deleteShiftObject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
