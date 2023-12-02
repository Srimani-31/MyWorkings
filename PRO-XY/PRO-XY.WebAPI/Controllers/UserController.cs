using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PRO_XY.WebAPI.Entities;
using System;

namespace PRO_XY.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
      Role role = new Role()
      {
        Id = 1,
        RoleName = "Admin",
        Description = "Full Access"
      };
      _logger.LogError("Greetings end point");
      return Ok(role);

    }
  }
}
