namespace SportsZoneWebAPI.DTOs
{
    public class OrderItemRequestDTO
    {
        public int OrderItemID { get; set; }
        public string OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string CreatedUpdatedBy { get; set; }
    }
}
