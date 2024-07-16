using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateControllers : ControllerBase
    {
        private readonly IStateServices _StateServices;
        public StateControllers(IStateServices StateServices)
        {
            _StateServices = StateServices;
        }
        // GET: api/<StateControllers>
        [HttpGet]
        public async Task<IEnumerable<State>> Get()
        {
            return await _StateServices.GetAllStatesAsync();
        }

        // GET api/<StateControllers>/5
        [HttpGet("{id}")]
        public async Task<State> Get(long id)
        {
            return await _StateServices.GetStateByIdAsync(id);
        }

        // POST api/<StateControllers>
        [HttpPost]
        public async Task<State> Post([FromBody] State state)
        {
            return await _StateServices.CreateStateAsync(state);
        }

        // PUT api/<StateControllers>/5
        [HttpPut("{id}")]
        public async Task<State> Put(long id, [FromBody] State state)
        {
            return await _StateServices.UpdateStateAsync(id, state);
        }

        // DELETE api/<StateControllers>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            return await _StateServices.DeleteStateAsync(id);
        }
    }
}
