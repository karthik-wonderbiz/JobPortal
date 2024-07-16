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
            return await _shiftServices.GetAllShiftsAsync();
        }

        // GET api/<ShiftController>/5
        [HttpGet("{id}")]
        public async Task<GetShiftDto> Get(long id)
        {
            return await _shiftServices.GetShiftByIdAsync(id);
        }

        // POST api/<ShiftController>
        [HttpPost]
        public async Task<GetShiftDto> Post([FromBody] CreateShiftDto shiftDto)
        {
            return await _shiftServices.CreateShiftAsync(shiftDto);
        }

        // PUT api/<ShiftController>/5
        [HttpPut("{id}")]
        public async Task<GetShiftDto> Put(long id, [FromBody] UpdateShiftDto shiftDto)
        {
            return await _shiftServices.UpdateShiftAsync(id, shiftDto);
        }

        // DELETE api/<ShiftController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            return await _shiftServices.DeleteShiftAsync(id);
        }
    }
}
