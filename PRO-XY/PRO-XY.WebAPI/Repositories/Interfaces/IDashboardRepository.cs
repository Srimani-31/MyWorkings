using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRO_XY.WebAPI.Entities;

namespace PRO_XY.WebAPI.Repositories.Interfaces
{
  public interface IDashboardRepository
  {
    Task GetDashboardbyId();
    Task GetAllDashboards();
    Task CreateJson();
    Task<Dashboard> AddDashboard();
    Task DeleteDashboard(int id);
  }
}
