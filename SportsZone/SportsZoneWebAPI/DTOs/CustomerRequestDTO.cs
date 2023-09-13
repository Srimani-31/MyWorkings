using System.ComponentModel.DataAnnotations;

namespace SportsZoneWebAPI.DTOs
{
    public class CustomerRequestDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string ProfilePhoto { get; set; }
        [Required]
        public string CreatedUpdatedBy { get; set; }
    }
}
