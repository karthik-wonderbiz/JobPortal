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
            var traininfosData = await _trainInfoServices.GetAllTrainInfosAsync();
            return traininfosData;
        }

        // GET api/<TrainInfoController>/5
        [HttpGet("{id}")]
        public async Task <ActionResult<GetTrainInfoDto>> Get(long id)
        {
            try {
            var traininfoData = await _trainInfoServices.GetTrainInfoByIdAsync(id);
            return traininfoData;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<TrainInfoController>
        [HttpPost]
        public async Task<ActionResult<GetTrainInfoDto>> Post([FromBody] CreateTrainInfoDto trainInfoDto)
        {
            try { 
            var createdTrainInfo = await _trainInfoServices.CreateTrainInfoAsync(trainInfoDto);
            return createdTrainInfo;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT api/<TrainInfoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetTrainInfoDto>> Put(long id, [FromBody] UpdateTrainInfoDto trainInfoDto)
        {
            try { 
            var updatedTrainInfo = await _trainInfoServices.UpdateTrainInfoAsync(id, trainInfoDto);
            return updatedTrainInfo;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<TrainInfoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try { 
            var deletedTrainInfo = await _trainInfoServices.DeleteTrainInfoAsync(id);
            return deletedTrainInfo;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
