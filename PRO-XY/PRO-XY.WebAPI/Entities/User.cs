using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace PRO_XY.WebAPI.Entities
{
  public partial class User
  {
    public User()
    {
      SharedDashboards = new HashSet<SharedDashboard>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public byte[] Password { get; set; }
    public string Address { get; set; }
    public string PhoneNo { get; set; }
    public int RoleId { get; set; }
    [JsonIgnore]
    public virtual Role Role { get; set; }
    [JsonIgnore]

    public virtual ICollection<SharedDashboard> SharedDashboards { get; set; }
  }
}
