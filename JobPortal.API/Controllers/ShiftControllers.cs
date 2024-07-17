using JobPortal.Data;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IEnumerable<GetShiftDto>> Get()
        {
            try
            {
                var getAllShiftObject = await _shiftServices.GetAllShiftsAsync();
                return getAllShiftObject;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<ShiftController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetShiftDto>> Get(long id)
        {
            try
            {
                var getShiftObject = await _shiftServices.GetShiftByIdAsync(id);
                return getShiftObject;
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ShiftController>
        [HttpPost]
        public async Task<GetShiftDto> Post([FromBody] CreateShiftDto shiftDto)
        {
            try
            {
                var createShiftObject = await _shiftServices.CreateShiftAsync(shiftDto);
                return createShiftObject;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<ShiftController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetShiftDto>> Put(long id, [FromBody] UpdateShiftDto shiftDto)
        {
            try
            {
                var updateShiftObject = await _shiftServices.UpdateShiftAsync(id, shiftDto);
                return updateShiftObject;
            }
            catch (Exception ex)
            {

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
                return deleteShiftObject;
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
