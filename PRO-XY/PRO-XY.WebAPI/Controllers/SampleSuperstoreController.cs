using Microsoft.AspNetCore.Mvc;
using PRO_XY.WebAPI.Repositories.Interfaces;

namespace PRO_XY.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SampleSuperstoreController : ControllerBase
  {
    private readonly ISampleSuperstoreRepository _repository;

    public SampleSuperstoreController(ISampleSuperstoreRepository repository)
    {
      _repository = repository;
    }

    [HttpGet, Route("getTotalSales")]
    public IActionResult GetTotalSales()
    {
      var totalSales = _repository.GetTotalSales();
      return Ok(totalSales);
    }
    [HttpGet, Route("getTotalProfit")]
    public IActionResult GetTotalProfit()
    {
      var totalProfit = _repository.GetTotalProfit();
      return Ok(totalProfit);
    }
    [HttpGet, Route("getProfitPercentage")]
    public IActionResult GetProfitPercentage()
    {
      var profitPercentage = _repository.GetProfitPercentage();
      return Ok(profitPercentage);
    }
    [HttpGet, Route("getSalesInState")]
    public IActionResult GetSalesInStateForChart()
    {
      var salesInState = _repository.GetSalesInStateForChart();
      return Ok(salesInState);
    }
    [HttpGet, Route("getShipModesSales")]

    public IActionResult GetShipModeSalesForChart()
    {
      var shipModeSales = _repository.GetShipModeSalesForChart();
      return Ok(shipModeSales);
    }
    [HttpGet, Route("getCategorySales")]

    public IActionResult GetCategorySalesForChart()
    {
      var categorySales = _repository.GetCategorySalesForChart();
      return Ok(categorySales);
    }
    [HttpGet, Route("getSegmentSales")]
    public IActionResult GetSegmentSalesForChart()
    {
      var segmentSales = _repository.GetSegmentSalesForChart();
      return Ok(segmentSales);
    }
    [HttpGet, Route("getRegionSales")]

    public IActionResult GetRegionSalesForChart()
    {
      var regionSales = _repository.GetRegionSalesForChart();
      return Ok(regionSales);
    }
    [HttpGet("getLineChartData")]
    public IActionResult GetLineChartData()
    {
      var result = _repository.GetShipModeSalesForChart();
      return Ok(result);
    }
  }
}
