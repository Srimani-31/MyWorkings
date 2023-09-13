using System.ComponentModel.DataAnnotations;

namespace SportsZoneWebAPI.DTOs
{
    public class ShippingRequestDTO
    {
        public int ShippingID { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Landmark { get; set; }
        [Required]
        public string BelongsTo { get; set; }
        [Required]
        public string CreatedUpdatedBy { get; set; }
    }
}
