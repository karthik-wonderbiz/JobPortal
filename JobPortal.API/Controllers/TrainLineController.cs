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
    public class TrainLineController : ControllerBase
    {
        private readonly ITrainLineServices _trainLineServices;

        public TrainLineController(ITrainLineServices trainLineServices)
        {
            _trainLineServices = trainLineServices;
        }

        // GET: api/<TrainLineController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTrainLineDto>>> Get()
        {
            try
            {
                var trainLines = await _trainLineServices.GetAllTrainLinesAsync();
                return Ok(trainLines);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<TrainLineController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTrainLineDto>> Get(long id)
        {
            try
            {
                var trainLine = await _trainLineServices.GetTrainLineByIdAsync(id);
                return Ok(trainLine);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<TrainLineController>
        [HttpPost]
        public async Task<ActionResult<GetTrainLineDto>> Post([FromBody] CreateTrainLineDto trainLineDto)
        {
            try
            {
                var createdTrainLine = await _trainLineServices.CreateTrainLineAsync(trainLineDto);
                return CreatedAtAction(nameof(Get), new { id = createdTrainLine.Id }, createdTrainLine);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<TrainLineController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetTrainLineDto>> Put(long id, [FromBody] UpdateTrainLineDto trainLineDto)
        {
            try
            {
                var updatedTrainLine = await _trainLineServices.UpdateTrainLineAsync(id, trainLineDto);
                return Ok(updatedTrainLine);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<TrainLineController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deleted = await _trainLineServices.DeleteTrainLineAsync(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
