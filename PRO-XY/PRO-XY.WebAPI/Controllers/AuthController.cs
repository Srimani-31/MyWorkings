using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRO_XY.WebAPI.Models;
using PRO_XY.WebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRO_XY.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly  IAuthRepository _authRepository;
    public AuthController(IAuthRepository authService)
    {
      _authRepository = authService;
    }

    [HttpPost, Route("Login")]
    public async Task<ActionResult> Login([FromBody] Login Login)
    {
      try
      {
        if (await _authRepository.IAuthenticatedUser(Login.Username, Login.Password))
        {
          //var token = await _authService.GenerateJwtToken(loginDTO);
          return Ok();
        }
        else
        {
          return Unauthorized();
        }
      }
      catch (Exception e)
      {
        return StatusCode(500, e.Message);
      }
    }

  }
}
