using System;
using System.Collections.Generic;
#nullable disable

namespace SportsZoneWebAPI.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
            Orders = new HashSet<Order>();
            IsEnabled = true;
        }

        public int CartID { get; set; }
        public string BelongsTo { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual Customer BelongsToNavigation { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
