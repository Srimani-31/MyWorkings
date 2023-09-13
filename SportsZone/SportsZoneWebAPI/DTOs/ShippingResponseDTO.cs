namespace SportsZoneWebAPI.DTOs
{
    public class ShippingResponseDTO
    {
        public int ShippingID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Landmark { get; set; }
        public string BelongsTo { get; set; }
    }
}
