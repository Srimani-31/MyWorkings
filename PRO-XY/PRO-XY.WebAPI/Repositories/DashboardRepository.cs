using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PRO_XY.WebAPI.Data;
using PRO_XY.WebAPI.Entities;
using PRO_XY.WebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace PRO_XY.WebAPI.Repositories
{
  public class DashboardRepository : IDashboardRepository
  {
    private readonly Pro_XYDbContext _dbContext;

    public DashboardRepository(Pro_XYDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<Dashboard>> GetAllDashboards()
    {
      return await _dbContext.Dashboards.ToListAsync();
    }

    public async Task<IEnumerable<Dashboard>> GetAllDashboardsByUserId(int userId)
    {
      IEnumerable<Guid> dashboardIds = await _dbContext.SharedDashboards
          .Where(x => x.UserId == userId)
          .Select(x => x.DashboardId)
          .ToListAsync();

      return await _dbContext.Dashboards
          .Where(d => dashboardIds.Contains(d.Id))
          .ToListAsync();
    }


    public async Task<Dashboard> GetDashboardbyId(Guid id)
    {
      return await _dbContext.Dashboards.FindAsync(id);
    }

    public async Task AddDashboard(List<object> data, int userId)
    {
      // Convert the list of objects to a JSON string
      string jsonData = JsonConvert.SerializeObject(data);

      // Create a new Dashboard instance
      Dashboard dashboard = new Dashboard
      {
        Id = Guid.NewGuid(),
        JsonValue = jsonData
      };

      // Add the Dashboard to the DbContext and save changes
      _dbContext.Dashboards.Add(dashboard);
      _dbContext.SaveChanges();

      // Create a new SharedDashboard instance
      SharedDashboard sharedDashboard = new SharedDashboard
      {
        DashboardId = dashboard.Id,
        UserId = userId
      };

      // Add the SharedDashboard to the DbContext and save changes
      _dbContext.SharedDashboards.Add(sharedDashboard);
      _dbContext.SaveChanges();
    }

    public async Task DeleteDashboard(Guid id)
    {
      Dashboard dashboard = await GetDashboardbyId(id);

      if (dashboard != null)
      {
        _dbContext.Dashboards.Remove(dashboard);
        await _dbContext.SaveChangesAsync();
      }
      else
      {
        throw new KeyNotFoundException("Role not found");
      }
    }

    public async Task<IEnumerable<string>> GetColumnNames<SampleSuperstore>()
    {
      await Task.CompletedTask;

      var entityType = _dbContext.Model.FindEntityType(typeof(SampleSuperstore));

      if (entityType != null)
      {
        return entityType.GetProperties().Select(p => p.GetColumnName()).ToList();
      }
      else
      {
        throw new ArgumentException($"Entity type {typeof(SampleSuperstore).Name} not found in the model.");
      }
    }
  }
}
