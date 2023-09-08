using System;
using System.Text.Json.Serialization;
#nullable disable

namespace SportsZoneWebAPI.Models
{
    public partial class Security
    {
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string SecurityQuestion { get; set; }
        public byte[] Answer { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        [JsonIgnore]
        public virtual Customer EmailNavigation { get; set; }
    }
}
