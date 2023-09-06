using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.DTOs
{
    public class SecurityRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string SecurityQuestion { get; set; }
        public string Answer { get; set; }      
        public string CreatedUpdatedBy { get; set; }
    }
}
