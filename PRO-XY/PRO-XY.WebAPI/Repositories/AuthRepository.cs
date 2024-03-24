using Microsoft.Extensions.Configuration;
using PRO_XY.WebAPI.Data.Interfaces;
using PRO_XY.WebAPI.Entities;
using PRO_XY.WebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRO_XY.WebAPI.Repositories
{
  public class AuthRepository : IAuthRepository
  {
    private readonly IHelper _helper;
    private readonly IProXYDbContext _dbContext;
    private readonly UserRepository _userRepository;

    public AuthRepository(IHelper helper, IProXYDbContext dbContext,UserRepository userRepository)
    {
      _helper = helper;
      _dbContext = dbContext;
      _userRepository = userRepository;
    }

    public async Task<bool> IsValidUsername(string username)
    {
      IEnumerable<User> users = await _userRepository.GetUsers();
      foreach (User user in users)
      {
        if (user.UserName == username)
          return true;
      }
      return false;
    }

    public async Task<bool> IsValidPassword(string password)
    {
      IEnumerable<User> users = await _userRepository.GetUsers();
      foreach (User user in users)
      {
        if (Helper.VerifyPassword(user.Password, password))
          return true;
      }
      return false;
    }

    public async Task<bool> IAuthenticatedUser(string username, string password)
    {
      return await IsValidUsername(username) && await IsValidPassword(password);         
    }
  }
}
