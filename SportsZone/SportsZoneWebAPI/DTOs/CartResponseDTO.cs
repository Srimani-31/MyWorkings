namespace SportsZoneWebAPI.DTOs
{
    public class CartResponseDTO
    {
        public int CartID { get; set; }
        public string BelongsTo { get; set; }
        public bool IsEnabled { get; set; }
    }
}
