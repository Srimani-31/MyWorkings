using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PRO_XY.WebAPI.Repositories.Interfaces
{
  public interface IHelper
  {
    public Task<bool> IsAvail<TEntity>(DbSet<TEntity> dbSet, string stringID = null, int intID = 0) where TEntity : class;
  }
}
