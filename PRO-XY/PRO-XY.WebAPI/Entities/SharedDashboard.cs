using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace PRO_XY.WebAPI.Entities
{
  public partial class SharedDashboard
  {
    public int Id { get; set; }
    public Guid DashboardId { get; set; }
    public int UserId { get; set; }
    [JsonIgnore]

    public virtual Dashboard Dashboard { get; set; }
    [JsonIgnore]

    public virtual User User { get; set; }
  }
}
