using Microsoft.AspNetCore.Mvc;
using PRO_XY.WebAPI.Entities;
using PRO_XY.WebAPI.Repositories;
using PRO_XY.WebAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace PRO_XY.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DashboardController : ControllerBase
  {
    private readonly IDashboardRepository _dashboardRepository;
    private readonly GraphDataRepository _graphDataRepository;

    public DashboardController(IDashboardRepository dashboardRepository, GraphDataRepository graphDataRepository)
    {
      _dashboardRepository = dashboardRepository;
      _graphDataRepository = graphDataRepository;
    }

    [HttpGet, Route("getColumnNames")]
    public async Task<ActionResult<IEnumerable<string>>> GetColumnNames()
    {
      try
      {
        var result = await _dashboardRepository.GetColumnNames<SampleSuperstore>();
        return Ok(result);
      }
      catch (Exception ex)
      {
        string message = ex.Message;
        return StatusCode(500);
      }

    }

    [HttpGet, Route("getAllChartData")]
    public async Task<ActionResult<IEnumerable<Dashboard>>> GetAllChartData()
    {
      var dashboards = await _dashboardRepository.GetAllDashboards();
      return Ok(dashboards);
    }

    [HttpGet, Route("getAllChartData/{userId}")]
    public async Task<ActionResult<IEnumerable<Dashboard>>> GetAllChartDataByUserId(int userId)
    {
      var dashboards = await _dashboardRepository.GetAllDashboardsByUserId(userId);
      return Ok(dashboards);
    }

    [HttpGet, Route("createChart/{dimension}/{measure}/{userId}")]
    public async Task<ActionResult<List<object>>> CreateChartData(string dimension, string measure, int userId)
    {
      var res = await _graphDataRepository.CreateJsonWithTwoAxis(dimension, measure);
      await _dashboardRepository.AddDashboard(res, userId);
      return Ok(res);
    }




  }
}
