using JobPortal.Data;
using JobPortal.DTO;
using JobPortal.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<GetTrainInfoDto>>> Get()
        {
            try
            {
                var trainInfos = await _trainInfoServices.GetAllTrainInfosAsync();
                return Ok(trainInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<TrainInfoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTrainInfoDto>> Get(long id)
        {
            try
            {
                var trainInfo = await _trainInfoServices.GetTrainInfoByIdAsync(id);
                return Ok(trainInfo);
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
            try
            {
                var createdTrainInfo = await _trainInfoServices.CreateTrainInfoAsync(trainInfoDto);
                return CreatedAtAction(nameof(Get), new { id = createdTrainInfo.Id }, createdTrainInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<TrainInfoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetTrainInfoDto>> Put(long id, [FromBody] UpdateTrainInfoDto trainInfoDto)
        {
            try
            {
                var updatedTrainInfo = await _trainInfoServices.UpdateTrainInfoAsync(id, trainInfoDto);
                return Ok(updatedTrainInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<TrainInfoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _trainInfoServices.DeleteTrainInfoAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
