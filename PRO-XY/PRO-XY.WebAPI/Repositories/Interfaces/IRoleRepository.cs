using PRO_XY.WebAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRO_XY.WebAPI.Repositories.Interfaces
{
  public interface IRoleRepository
  {
    public Task<bool> IsAvail(int roleId);
    public Task<IEnumerable<Role>> GetRoles();
    public Task<Role> GetRoleById(int roleId);
    public Task CreateRole(Role role);
    public Task UpdateRole(Role role);
    public Task DeleteRole(int roleId);
  }
}
