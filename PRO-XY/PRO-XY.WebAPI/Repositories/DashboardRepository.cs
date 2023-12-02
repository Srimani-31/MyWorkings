using System;
using System.Collections.Generic;
using System.Linq;
using PRO_XY.WebAPI.Repositories.Interfaces;
using System.Threading.Tasks;
using PRO_XY.WebAPI.Data.Interfaces;
using PRO_XY.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace PRO_XY.WebAPI.Repositories
{
  public class DashboardRepository : IDashboardRepository
  {
    private readonly IProXYDbContext _dbContext;
    public DashboardRepository(IProXYDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<Dashboard>> GetAllDashboards()
    {
      return await _dbContext.Dashboards.ToListAsync();

    }
  }
}
