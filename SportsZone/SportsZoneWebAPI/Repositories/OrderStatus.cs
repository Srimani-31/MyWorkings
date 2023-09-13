using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories
{
    public static class OrderStatus
    {
        public const string Placed = "Placed";
        public const string Delivered = "Delivered";
        public const string Cancelled = "Cancelled";
        public const string Returned = "Returned";
    }

}
