using System;
using System.Collections.Generic;
#nullable disable

namespace SportsZoneWebAPI.Models
{
    public partial class Shipping
    {
        public Shipping()
        {
            Orders = new HashSet<Order>();
        }

        public int ShippingID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Landmark { get; set; }
        public string BelongsTo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual Customer BelongsToNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
