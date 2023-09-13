using System.ComponentModel.DataAnnotations;

namespace SportsZoneWebAPI.DTOs
{
    public class CartRequestDTO
    {
        public int CartID { get; set; }
        [Required]
        public string BelongsTo { get; set; }
        [Required]
        public string CreatedUpdatedBy { get; set; }
    }
}
