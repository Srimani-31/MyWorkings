using System.Collections.Generic;

namespace PRO_XY.WebAPI.Repositories.Interfaces
{
  public interface ISampleSuperstoreRepository
  {
    decimal GetTotalSales();
    decimal GetTotalProfit();
    decimal GetProfitPercentage();
    List<object> GetRegionSalesForChart();
    List<object> GetSegmentSalesForChart();
    List<object> GetCategorySalesForChart();
    List<object> GetShipModeSalesForChart();
    List<object> GetSalesInStateForChart();
    List<Dictionary<string, object>> GetLineChartData();


  }
}
