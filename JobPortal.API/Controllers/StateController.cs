using JobPortal.Data;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IEnumerable<GetStateDto>> Get()
        {
            return await _stateServices.GetAllStatesAsync();
        }

        // GET api/<StateController>/5
        [HttpGet("{id}")]
        public async Task<GetStateDto> Get(long id)
        {
            return await _stateServices.GetStateByIdAsync(id);
        }

        // POST api/<StateController>
        [HttpPost]
        public async Task<GetStateDto> Post([FromBody] CreateStateDto stateDto)
        {
            return await _stateServices.CreateStateAsync(stateDto);
        }

        // PUT api/<StateController>/5
        [HttpPut("{id}")]
        public async Task<GetStateDto> Put(long id, [FromBody] UpdateStateDto stateDto)
        {
            return await _stateServices.UpdateStateAsync(id, stateDto);
        }

        // DELETE api/<StateController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            return await _stateServices.DeleteStateAsync(id);
        }
    }
}
