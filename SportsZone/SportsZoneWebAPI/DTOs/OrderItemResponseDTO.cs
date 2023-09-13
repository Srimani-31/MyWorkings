namespace SportsZoneWebAPI.DTOs
{
    public class OrderItemResponseDTO
    {
        public int OrderItemID { get; set; }
        public string OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
