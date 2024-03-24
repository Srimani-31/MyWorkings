using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRO_XY.WebAPI.Repositories.Interfaces;

namespace PRO_XY.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SharedDashboardController : ControllerBase
  {
    private readonly ISharedDashboardRepository _sharedDashboardRepository;

    public SharedDashboardController(ISharedDashboardRepository sharedDashboardRepository)
    {
      _sharedDashboardRepository = sharedDashboardRepository;
    }

    [HttpGet,Route("getDashboardIdsByUserId")]
    public async Task<ActionResult<IEnumerable<int>>> GetDashboardIdsByUserId(int userId)
    {
      var ids = await _sharedDashboardRepository.GetDashboardIdsByUserId(userId);
      return Ok(ids);
    }
  }
}
