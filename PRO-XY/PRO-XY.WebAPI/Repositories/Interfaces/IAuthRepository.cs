using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRO_XY.WebAPI.Repositories.Interfaces
{
  public interface IAuthRepository
  {
    public Task<bool> IsValidUsername(string username);
    public Task<bool> IsValidPassword(string password);
    public Task<bool> IAuthenticatedUser(string username, string password);

  }
}
