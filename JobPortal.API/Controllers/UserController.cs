using JobPortal.Data;
using JobPortal.IServices;
using JobPortal.Model;
using JobPortal.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices UserServices)
        {
            _userServices = UserServices;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> Get()
        {
            try
            {
                var countriesData = await _userServices.GetAllUsersAsync();
                return Ok(countriesData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDto>> Get(long id)
        {
            try
            {
                var UserData = await _userServices.GetUserByIdAsync(id);
                return Ok(UserData);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<GetUserDto>> Post([FromBody] CreateUserDto UserDto)
        {
            try
            {
                var createdUser = await _userServices.CreateUserAsync(UserDto);
                return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                if (ex.Message == "This input already exists.")
                {
                    return Conflict(ex.Message);
                }
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetUserDto>> Put(long id, [FromBody] UpdateUserDto UserDto)
        {
            try
            {
                var updatedUser = await _userServices.UpdateUserAsync(id, UserDto);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                if (ex.Message == "This input already exists.")
                {
                    return Conflict(ex.Message);
                }
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var deletedUser = await _userServices.DeleteUserAsync(id);
                return Ok(deletedUser);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
