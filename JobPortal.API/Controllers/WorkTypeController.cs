using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IEnumerable<WorkType>> Get()
        {
            return await _workTypeServices.GetWorkTypeAsync();
        }

        // GET api/<WorkTypeController>/5
        [HttpGet("{id}")]
        public async Task<WorkType> Get(long id)
        {
            return await _workTypeServices.GetWorkTypeById(id);
        }

        // POST api/<WorkTypeController>
        [HttpPost]
        public async Task<WorkType> Post([FromBody] WorkType workType)
        {
            return await _workTypeServices.CreateWorkTypeAsync(workType);
        }

        // PUT api/<WorkTypeController>/5
        [HttpPut("{id}")]
        public async Task<WorkType> Put(long id, [FromBody] WorkType workType)
        {
            return await _workTypeServices.UpdateWorkTypeAsync(id, workType);
        }

        // DELETE api/<WorkTypeController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            return await _workTypeServices.DeleteWorkTypeAsync(id);
        }
    }
}
