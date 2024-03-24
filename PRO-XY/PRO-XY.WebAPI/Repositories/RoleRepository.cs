using Microsoft.EntityFrameworkCore;
using PRO_XY.WebAPI.Data.Interfaces;
using PRO_XY.WebAPI.Entities;
using PRO_XY.WebAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRO_XY.WebAPI.Repositories
{
  public class RoleRepository : IRoleRepository
  {
    private readonly IHelper _helper;
    private readonly IProXYDbContext _dbContext;

    public RoleRepository(IHelper helper, IProXYDbContext dbContext)
    {
      _helper = helper;
      _dbContext = dbContext;
    }

    public async Task CreateRole(Role role)
    {
      _dbContext.Roles.Add(role);
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteRole(int roleId)
    {
      Role role = await GetRoleById(roleId);

      if (role != null)
      {
        _dbContext.Roles.Remove(role);
        await _dbContext.SaveChangesAsync();
      }
      else
      {
        throw new KeyNotFoundException("Role not found");
      }
    }

    public async Task<Role> GetRoleById(int roleId)
    {
      Role role = await _dbContext.Roles.FindAsync(roleId);
      return role;
    }

    public async Task<IEnumerable<Role>> GetRoles()
    {
      return await _dbContext.Roles.ToListAsync();
    }

    public async Task<bool> IsAvail(int roleId)
    {
      return await _helper.IsAvail(dbSet: _dbContext.Roles, intID: roleId);
    }

    public async Task UpdateRole(Role role)
    {
      _dbContext.Roles.Update(role);
      await _dbContext.SaveChangesAsync();
    }
  }
}
