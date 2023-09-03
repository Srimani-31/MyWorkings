using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiddleWebAPI.Service;
using RiddleWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using RiddleWebAPI.Dtos;

namespace RiddleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet,Route("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUserAsync();
                return StatusCode(200, users);
                //return Ok(users);
            }
            catch(Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
           
        }
        [HttpGet,Route("GetUserByName/{username}")]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            try
            {   
                var user = await _userService.GetUserByUsernameAsync(username);
                if (user == null)
                {
                    return StatusCode(404,"User not found");
                }
                return Ok(user);
            }
            catch(Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
           
        }
        [HttpPost,Route("AddUser")]
        public async Task<ActionResult<User>> AddUser(UserDto userDto)
        {
            try
            {
                await _userService.AddUserAsync(userDto);
                return StatusCode(201,"New User created successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(501, ex.InnerException);
            }
            
        }

        [HttpPut,Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
            try
            {
                await _userService.UpdateUserAsync(userDto);
                return StatusCode(200,"User updated successfully");
            }
            //catch(InvalidOperationException ex)
            //{
            //    return StatusCode(400, ex.TargetSite);
            //}
            //catch(NullReferenceException ex)
            //{
            //    return StatusCode(404, ex.Message);
            //}
            //catch(KeyNotFoundException ex)
            //{
            //    return StatusCode(404, ex.Message);
            //}
            catch(Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
           
        }
        [HttpDelete,Route("DeleteUser/{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            try
            {
                await _userService.DeleteUserAsync(username);
                return StatusCode(200,"User removed successfully.");
            }
            catch(KeyNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
            
        }
        [HttpPost,Route("AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser(LoginDto loginDto)
        {
            try
            {
                if(await _userService.AuthenticateUser(loginDto))
                {
                    return StatusCode(200, "User authenticated successfully");
                }
                return StatusCode(201, "Unauthenticated user.");
            }
            catch(Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
    }
}
