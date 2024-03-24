using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PRO_XY.WebAPI.Entities;
using PRO_XY.WebAPI.Models;
using PRO_XY.WebAPI.Repositories;
using System;
using System.Threading.Tasks;

namespace PRO_XY.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly UserRepository _userRepository;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, UserRepository userRepository)
    {
      _userRepository = userRepository;
      _logger = logger;
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateCustomer([FromForm] UserDto user)
    {

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (await _userRepository.IsAvail(user.UserName))
      {
        return Conflict();
      }
      await _userRepository.CreateUser(user);
      return Ok(user);
    }
  }
}
