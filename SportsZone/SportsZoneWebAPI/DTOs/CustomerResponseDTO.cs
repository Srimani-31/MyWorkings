namespace SportsZoneWebAPI.DTOs
{
    public class CustomerResponseDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string ProfilePhoto { get; set; }
        public bool? IsEnabled { get; set; }
    }
}
