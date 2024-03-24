using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace PRO_XY.WebAPI.Entities
{
  public partial class Role
  {
    public Role()
    {
      Users = new HashSet<User>();
    }

    public int Id { get; set; }
    public string RoleName { get; set; }
    public string Description { get; set; }
    [JsonIgnore]

    public virtual ICollection<User> Users { get; set; }
  }
}
