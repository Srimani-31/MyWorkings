﻿using System;
#nullable disable

namespace SportsZoneWebAPI.Models
{
    public partial class OrderItem
    {
        public int OrderItemID { get; set; }
        public string OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
