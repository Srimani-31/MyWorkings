using System;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        [Required]
        public int PaymentID { get; set; }
        [Required]
        public int ShippingID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int? CartID { get; set; }
        [Required]
        public string CreatedUpdatedBy { get; set; }
    }
}
