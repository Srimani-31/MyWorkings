using System;

namespace SportsZoneWebAPI.DTOs
{
    public class OrderRequestDTO
    {
        public OrderRequestDTO()
        {
            OrderDate = DateTime.Now;
            Status = "Placed";
        }
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public int PaymentID { get; set; }
        public int ShippingID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int? CartID { get; set; }
        public string CreatedUpdatedBy { get; set; }
    }
}
