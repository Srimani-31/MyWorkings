namespace SportsZoneWebAPI.DTOs
{
    public class CartItemRequestDTO
    {
        public int CartItemID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string CreatedUpdatedBy { get; set; }
    }
}
