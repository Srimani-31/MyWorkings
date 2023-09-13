using System.ComponentModel.DataAnnotations;

namespace SportsZoneWebAPI.DTOs
{
    public class PaymentRequestDTO
    {
        public int PaymentID { get; set; }
        [Required]
        public string PaymentType { get; set; }
        [Required]
        public string CreatedUpdatedBy { get; set; }
    }
}
