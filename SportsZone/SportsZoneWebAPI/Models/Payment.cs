using System;
using System.Collections.Generic;
#nullable disable

namespace SportsZoneWebAPI.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentID { get; set; }
        public string PaymentType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
