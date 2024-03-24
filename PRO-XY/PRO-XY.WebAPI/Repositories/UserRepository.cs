using Microsoft.EntityFrameworkCore;
using PRO_XY.WebAPI.Data.Interfaces;
using PRO_XY.WebAPI.Entities;
using PRO_XY.WebAPI.Models;
using PRO_XY.WebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRO_XY.WebAPI.Repositories
{
  public class UserRepository
  {
    private readonly IHelper _helper;
    private readonly IProXYDbContext _dbContext;

    public UserRepository(IHelper helper, IProXYDbContext dbContext)
    {
      _helper = helper;
      _dbContext = dbContext;
    }

    public async Task CreateUser(UserDto userDto)
    {
      try
      {
        User user = new User()
        {
          UserName = userDto.UserName,
          Name = userDto.Name,
          Address = userDto.Address,
          PhoneNo = userDto.PhoneNo,
          RoleId = userDto.RoleId,
          Password = Helper.HashItemToBytes(userDto.Password)
        };
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        string message = ex.Message;
        throw;
      }

    }

    public async Task DeleteUser(int userId)
    {
      User user = await GetUserById(userId);

      if (user != null)
      {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
      }
      else
      {
        throw new KeyNotFoundException("User not found");
      }
    }

    public async Task<User> GetUserById(int userId)
    {
      User user = await _dbContext.Users.FindAsync(userId);
      return user;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
      return await _dbContext.Users.ToListAsync();
    }

    public async Task<bool> IsAvail(int userId)
    {
      return await _helper.IsAvail(dbSet: _dbContext.Users, intID: userId);
    }

    public async Task<bool> IsAvail(string userName)
    {
      var normalizedUserName = userName.ToUpper();
      var isAvailable = await _dbContext.Users
          .Where(u => u.UserName.ToUpper() == normalizedUserName)
          .AnyAsync();

      // If isAvailable is true, the username is not available; otherwise, it is available
      return isAvailable;
    }

    public async Task UpdateRole(User user)
    {
      _dbContext.Users.Update(user);
      await _dbContext.SaveChangesAsync();
    }
  }
}
