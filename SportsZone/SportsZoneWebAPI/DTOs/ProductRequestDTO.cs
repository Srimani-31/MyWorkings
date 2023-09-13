using System.ComponentModel.DataAnnotations;

namespace SportsZoneWebAPI.DTOs
{
    public class ProductRequestDTO
    {
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public int StockCount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string CreatedUpdatedBy { get; set; }
    }
}
