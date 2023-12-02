using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRO_XY.WebAPI.Data.Interfaces;
using PRO_XY.WebAPI.Repositories.Interfaces;

namespace PRO_XY.WebAPI.Repositories
{
  public class Helper : IHelper
  {
    private readonly IProXYDbContext _dbContext;
    public Helper(IProXYDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<bool> IsAvail<TEntity>(DbSet<TEntity> dbSet, string stringID = null, int intID = 0) where TEntity : class
    {
      bool isAvail = false;
      if (!string.IsNullOrWhiteSpace(stringID))
      {
        if (await dbSet.FindAsync(stringID) != null)
          isAvail = true;
      }
      else
      {
        if (await dbSet.FindAsync(intID) != null)
          isAvail = true;
      }
      return isAvail;
    }
  }
}
