using PRO_XY.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRO_XY.WebAPI.Repositories.Interfaces
{
  public interface ISharedDashboardRepository
  {
    Task<IEnumerable<Guid>> GetDashboardIdsByUserId(int userId);
    Task RemoveAccessToUserId(Guid dashboardId, int userId);
    Task GrantAccessToUserId(Guid dashbardId, int userId);
  }
}
