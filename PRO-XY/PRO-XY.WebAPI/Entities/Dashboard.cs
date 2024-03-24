using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace PRO_XY.WebAPI.Entities
{
  public partial class Dashboard
  {
    public Dashboard()
    {
      SharedDashboards = new HashSet<SharedDashboard>();
    }

    public Guid Id { get; set; }
    public string JsonValue { get; set; }
    [JsonIgnore]
    public virtual ICollection<SharedDashboard> SharedDashboards { get; set; }
  }
}
