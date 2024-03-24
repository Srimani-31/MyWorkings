using Microsoft.EntityFrameworkCore;
using PRO_XY.WebAPI.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PRO_XY.WebAPI.Data.Interfaces
{
  public interface IProXYDbContext
  {
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    DbSet<Dashboard> Dashboards { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<SharedDashboard> SharedDashboards { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<SampleSuperstore> SampleSuperstores { get; set; }

  }
}
