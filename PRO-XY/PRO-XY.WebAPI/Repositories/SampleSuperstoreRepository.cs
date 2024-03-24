using PRO_XY.WebAPI.Data.Interfaces;
using PRO_XY.WebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PRO_XY.WebAPI.Repositories
{
  public class SampleSuperstoreRepository : ISampleSuperstoreRepository
  {
    private readonly IProXYDbContext _dbContext;

    public SampleSuperstoreRepository(IProXYDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public decimal GetTotalSales()
    {
      var totalSales = _dbContext.SampleSuperstores
        .Where(s => s.OrderDate.HasValue)
        .Sum(s => s.Sales);

      return Math.Ceiling(Convert.ToDecimal(totalSales));
    }

    public decimal GetTotalProfit()
    {
      // Perform the query
      var totalProfit = _dbContext.SampleSuperstores
          .Sum(s => s.Profit);

      return Math.Ceiling(Convert.ToDecimal(totalProfit));
    }

    public decimal GetProfitPercentage()
    {
      var result = _dbContext.SampleSuperstores
          .Select(s => Math.Round((decimal)((s.Profit / s.Sales) * 100), 2))
          .FirstOrDefault();

      return result;
    }

    public List<object> GetRegionSalesForChart()
    {
      // Perform the query
      var regionSales = _dbContext.SampleSuperstores
          .GroupBy(s => s.Region)
          .Select(group => new
          {
            Region = group.Key,
            RegionSales = Math.Ceiling(Convert.ToDecimal(group.Sum(s => s.Sales)))
          })
          .ToList<object>();

      return regionSales;
    }

    public List<object> GetSegmentSalesForChart()
    {
      // Perform the query
      var segmentSales = _dbContext.SampleSuperstores
          .GroupBy(s => s.Segment)
          .Select(group => new
          {
            Segment = group.Key,
            SegmentSales = Math.Ceiling(Convert.ToDecimal(group.Sum(s => s.Sales)))
          })
          .ToList<object>();

      return segmentSales;
    }

    public List<object> GetCategorySalesForChart()
    {
      // Perform the query
      var categorySales = _dbContext.SampleSuperstores
          .GroupBy(s => s.Category)
          .Select(group => new
          {
            Category = group.Key,
            CategorySales = Math.Ceiling(Convert.ToDecimal(group.Sum(s => s.Sales)))
          })
          .ToList<object>();

      return categorySales;
    }

    public List<object> GetShipModeSalesForChart()
    {
      // Perform the query
      var shipModeSales = _dbContext.SampleSuperstores
                .GroupBy(s => s.ShipMode)
                .Select(group => new
                {
                  ShipMode = group.Key,
                  ShipModeSales = Math.Ceiling(Convert.ToDecimal(group.Sum(s => s.Sales)))
                })
                .ToList<object>();

      return shipModeSales;
    }

    public List<object> GetSalesInStateForChart()
    {
      // Perform the query
      var salesInState = _dbContext.SampleSuperstores
          .GroupBy(s => s.State)
          .Select(group => new
          {
            State = group.Key,
            SalesInState = Math.Ceiling(Convert.ToDecimal(group.Sum(s => s.Sales)))
          })
          .ToList<object>();

      return salesInState;
    }

    public List<Dictionary<string, object>> GetLineChartData()
    {
      var result = _dbContext.SampleSuperstores
          .GroupBy(s => s.OrderDate)
          .AsEnumerable()
          .Select(g => new Dictionary<string, object>
          {
            { "OrderDate", g.Key },
            { "TotalSales", g.Sum(s => s.Sales) }
          })
          .ToList()
          .OrderBy(x => (DateTime)x["OrderDate"])
          .ToList();

      return result;
    }
  }
}
