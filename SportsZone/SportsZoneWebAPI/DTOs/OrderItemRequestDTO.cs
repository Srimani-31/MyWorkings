using System.ComponentModel.DataAnnotations;

namespace SportsZoneWebAPI.DTOs
{
    public class OrderItemRequestDTO
    {
        public int OrderItemID { get; set; }
        [Required]
        public string OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string CreatedUpdatedBy { get; set; }
    }
}
