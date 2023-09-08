namespace SportsZoneWebAPI.DTOs
{
    public class CartRequestDTO
    {
        public int CartID { get; set; }
        public string BelongsTo { get; set; }
        public string CreatedUpdatedBy { get; set; }
    }
}
