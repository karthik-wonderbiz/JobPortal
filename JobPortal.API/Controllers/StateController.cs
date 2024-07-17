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
            try
            {
                var getAllStateObject = await _stateServices.GetAllStatesAsync();
                return getAllStateObject;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<StateController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetStateDto>> Get(long id)
        {
            try
            {
                var getStateObject = await _stateServices.GetStateByIdAsync(id);
                return getStateObject;
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<StateController>
        [HttpPost]
        public async Task<GetStateDto> Post([FromBody] CreateStateDto stateDto)
        {
            try
            {
                var createStateObject = await _stateServices.CreateStateAsync(stateDto);
                return createStateObject;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<StateController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetStateDto>> Put(long id, [FromBody] UpdateStateDto stateDto)
        {
            try
            {
                var updateStateObject = await _stateServices.UpdateStateAsync(id, stateDto);
                return updateStateObject;
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<StateController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleteStateObject = await _stateServices.DeleteStateAsync(id);
                return deleteStateObject;
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
