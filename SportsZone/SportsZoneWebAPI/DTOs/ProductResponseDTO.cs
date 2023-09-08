namespace SportsZoneWebAPI.DTOs
{
    public class ProductResponseDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int StockCount { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
}
