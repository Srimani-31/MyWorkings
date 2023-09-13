using System.ComponentModel.DataAnnotations;

namespace SportsZoneWebAPI.DTOs
{
    public class CategoryRequestDTO
    {
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CreatedUpdatedBy { get; set; }
    }
}
