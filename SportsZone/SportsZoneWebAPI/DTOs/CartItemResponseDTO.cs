namespace SportsZoneWebAPI.DTOs
{
    public class CartItemResponseDTO
    {
        public int CartItemID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        //response & request dto attribute
    }
}
