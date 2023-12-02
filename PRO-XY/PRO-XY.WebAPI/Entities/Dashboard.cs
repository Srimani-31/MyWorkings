using System;
using System.Collections.Generic;

#nullable disable

namespace PRO_XY.WebAPI.Entities
{
    public partial class Dashboard
    {
        public Dashboard()
        {
            SharedDashboards = new HashSet<SharedDashboard>();
        }

        public int Id { get; set; }
        public string JsonValue { get; set; }

        public virtual ICollection<SharedDashboard> SharedDashboards { get; set; }
    }
}
