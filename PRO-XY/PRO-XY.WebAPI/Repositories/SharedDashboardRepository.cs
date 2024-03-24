using PRO_XY.WebAPI.Entities;
using PRO_XY.WebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRO_XY.WebAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PRO_XY.WebAPI.Repositories
{
  public class SharedDashboardRepository : ISharedDashboardRepository
  {
    private readonly IProXYDbContext _dbContext;

    public SharedDashboardRepository(IProXYDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<Guid>> GetDashboardIdsByUserId(int userId)
    {
      IEnumerable<SharedDashboard> sharedDashboards = _dbContext.SharedDashboards.Where(x => x.UserId == userId).ToList();
      IEnumerable<Guid> dashboardIds = sharedDashboards.Select(x => x.DashboardId).ToList();

      return dashboardIds;
    }

    public async Task GrantAccessToUserId(Guid dashbardId, int userId)
    {
      SharedDashboard sharedDashboard = new SharedDashboard()
      {
        DashboardId = dashbardId,
        UserId = userId
      };
      _dbContext.SharedDashboards.Add(sharedDashboard);
      await _dbContext.SaveChangesAsync();

    }

    public async Task RemoveAccessToUserId(Guid dashboardId, int userId)
    {
      SharedDashboard sharedDashboard = await _dbContext.SharedDashboards
            .FirstOrDefaultAsync(x => x.DashboardId == dashboardId && x.UserId == userId);
      _dbContext.SharedDashboards.Remove(sharedDashboard);
      await _dbContext.SaveChangesAsync();
    }
  }
}
