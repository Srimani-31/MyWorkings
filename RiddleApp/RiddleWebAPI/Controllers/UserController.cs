using Microsoft.AspNetCore.Mvc;
using RiddleWebAPI.Dtos;
using RiddleWebAPI.Models;
using RiddleWebAPI.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiddleWebAPI.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            try
            {

                var users = await _userService.GetAllUserAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }

        }
        [HttpGet, Route("{username}")]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            try
            {
                var user = await _userService.GetUserByUsernameAsync(username);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound("User not found");
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] UserDto userDto)
        {
            try
            {
                await _userService.AddUserAsync(userDto);
                return StatusCode(201, "New User created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.InnerException);
            }

        }

        [HttpPut, Route("{username}")]
        public async Task<IActionResult> UpdateUser([FromRoute] string username, [FromBody] UserDto userDto)
        {
            try
            {
                if (await _userService.IsAvail(username))
                {
                    await _userService.UpdateUserAsync(userDto);
                    return Ok(userDto);
                }
                return NotFound("User not found");
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }

        }
        [HttpDelete, Route("{username}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string username)
        {
            try
            {
                if (await _userService.IsAvail(username))
                {
                    await _userService.DeleteUserAsync(username);
                    return Ok();
                }
                return NotFound("User not found");
            }
            catch (KeyNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }
        [HttpPost, Route("AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser([FromBody] LoginDto loginDto)
        {
            try
            {
                if (await _userService.AuthenticateUser(loginDto))
                {
                    return StatusCode(200, "User authenticated successfully");
                }
                return StatusCode(201, "Unauthenticated user.");
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
    }
}
