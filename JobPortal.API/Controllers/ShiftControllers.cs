using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftControllers : ControllerBase
    {
        private readonly IShiftServices _shiftServices;
        public ShiftControllers(IShiftServices shiftServices)
        {
            _shiftServices = shiftServices;
        }
        // GET: api/<ShiftControllers>
        [HttpGet]
        public async Task <IEnumerable<Shift>> Get()
        {
            return await _shiftServices.GetAllShiftsAsync();
        }

        // GET api/<ShiftControllers>/5
        [HttpGet("{id}")]
        public async Task <Shift> Get(long id)
        {
            return await _shiftServices.GetShiftByIdAsync(id);
        }

        // POST api/<ShiftControllers>
        [HttpPost]
        public async Task<Shift> Post([FromBody] Shift Shift)
        {
            return await _shiftServices.CreateShiftAsync(Shift);
        }

        // PUT api/<ShiftControllers>/5
        [HttpPut("{id}")]
        public async Task<Shift> Put(long id, [FromBody] Shift Shift)
        {
            return await _shiftServices.UpdateShiftAsync(id, Shift);
        }

        // DELETE api/<ShiftControllers>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            return await _shiftServices.DeleteShiftAsync(id);
        }
    }
}
