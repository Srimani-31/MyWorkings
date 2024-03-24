using System;
using System.Collections.Generic;

#nullable disable

namespace PRO_XY.WebAPI.Entities
{
    public partial class SharedDashboard
    {
        public int Id { get; set; }
        public int? DashboardId { get; set; }
        public int? UserId { get; set; }

        public virtual Dashboard Dashboard { get; set; }
        public virtual User User { get; set; }
    }
}
