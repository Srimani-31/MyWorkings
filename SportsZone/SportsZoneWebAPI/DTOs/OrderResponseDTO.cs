using System;

namespace SportsZoneWebAPI.DTOs
{
    public class OrderResponseDTO
    {
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public int PaymentID { get; set; }
        public int ShippingID { get; set; }
        public int? CartID { get; set; }
    }
}
