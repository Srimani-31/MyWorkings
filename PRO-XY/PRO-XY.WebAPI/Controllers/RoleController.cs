using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRO_XY.WebAPI.Repositories.Interfaces;
using PRO_XY.WebAPI.Entities;

namespace PRO_XY.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RoleController : ControllerBase
  {
    private readonly IRoleRepository _roleRepository;

    public RoleController(IRoleRepository roleRepository)
    {
      _roleRepository = roleRepository;
    }

    [HttpGet,Route("getAllRoles")]
    public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
    {
      var roles = await _roleRepository.GetRoles();
      return Ok(roles);
    }
  }

}
