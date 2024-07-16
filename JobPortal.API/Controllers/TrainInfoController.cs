using JobPortal.Data;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.API.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public class TrainInfoController : ControllerBase
    {
        private readonly ITrainInfoServices _trainInfoServices;

        public TrainInfoController(ITrainInfoServices trainInfoServices)
        {
            _trainInfoServices = trainInfoServices;
        }


        // GET: api/<TrainInfoController>
        [HttpGet]
        public async Task<IEnumerable<GetTrainInfoDto>> Get()
        {
            return await _trainInfoServices.GetAllTrainInfosAsync();
        }

        // GET api/<TrainInfoController>/5
        [HttpGet("{id}")]
        public async Task<GetTrainInfoDto> Get(long id)
        {
            return await _trainInfoServices.GetTrainInfoByIdAsync(id);
        }

        // POST api/<TrainInfoController>
        [HttpPost]
        public async Task<GetTrainInfoDto> Post([FromBody] CreateTrainInfoDto trainInfoDto)
        {
            return await _trainInfoServices.CreateTrainInfoAsync(trainInfoDto);
        }

        // PUT api/<TrainInfoController>/5
        [HttpPut("{id}")]
        public async Task<GetTrainInfoDto> Put(long id, [FromBody] UpdateTrainInfoDto trainInfoDto)
        {
            return await _trainInfoServices.UpdateTrainInfoAsync(id, trainInfoDto);
        }

        // DELETE api/<TrainInfoController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            return await _trainInfoServices.DeleteTrainInfoAsync(id);
        }
    }
}
