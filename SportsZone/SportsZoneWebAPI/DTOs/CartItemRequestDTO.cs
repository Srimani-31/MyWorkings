using System.ComponentModel.DataAnnotations;

namespace SportsZoneWebAPI.DTOs
{
    public class CartItemRequestDTO
    {
        public int CartItemID { get; set; }
        [Required]
        public int CartID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string CreatedUpdatedBy { get; set; }
    }
}
