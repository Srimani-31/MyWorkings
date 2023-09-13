using System.ComponentModel.DataAnnotations;

namespace SportsZoneWebAPI.DTOs
{
    public class SecurityRequestDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string SecurityQuestion { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        public string CreatedUpdatedBy { get; set; }
    }
}
