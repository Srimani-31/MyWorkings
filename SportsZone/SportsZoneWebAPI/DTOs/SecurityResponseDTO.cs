namespace SportsZoneWebAPI.DTOs
{
    public class SecurityResponseDTO
    {
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string SecurityQuestion { get; set; }
        public byte[] Answer { get; set; }
    }
}
