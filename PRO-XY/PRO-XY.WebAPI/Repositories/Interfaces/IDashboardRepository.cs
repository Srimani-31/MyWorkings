using PRO_XY.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRO_XY.WebAPI.Repositories.Interfaces
{
  public interface IDashboardRepository
  {
    Task<Dashboard> GetDashboardbyId(Guid dashboardId);
    Task<IEnumerable<Dashboard>> GetAllDashboards();
    Task<IEnumerable<Dashboard>> GetAllDashboardsByUserId(int userId);
    Task AddDashboard(List<object> data,int userId);
    Task DeleteDashboard(Guid id);
    Task<IEnumerable<string>> GetColumnNames<SampleSuperstore>();

  }
}
