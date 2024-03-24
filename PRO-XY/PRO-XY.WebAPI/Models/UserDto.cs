using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRO_XY.WebAPI.Models
{
  public class UserDto
  {
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string PhoneNo { get; set; }
    public int RoleId { get; set; }
  }
}
