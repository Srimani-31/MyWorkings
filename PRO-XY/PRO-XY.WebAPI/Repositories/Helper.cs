using Microsoft.EntityFrameworkCore;
using PRO_XY.WebAPI.Data.Interfaces;
using PRO_XY.WebAPI.Repositories.Interfaces;
using System.Text;
using System.Threading.Tasks;

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
    public static bool VerifyPassword(byte[] hashedPassword, string enteredPassword)
    {
      // Convert the byte[] hashed password to a string
      string hashedPasswordString = Encoding.UTF8.GetString(hashedPassword);

      // Use BCrypt's Verify method to compare the entered password with the hashed password
      bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPasswordString);

      return isPasswordMatch;
    }
    public static byte[] HashItemToBytes(string password)
    {
      return Encoding.UTF8.GetBytes(BCrypt.Net.BCrypt.HashPassword(password));
    }
  }
}
