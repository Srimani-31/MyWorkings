using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.DTOs
{
    public class SecurityRequestDTO
    {
        public string Email { get; set; }
        public string NormalPassword { get; set; }
        public string SecurityQuestion { get; set; }
        public string NormalAnswer { get; set; }      
        public string CreatedUpdatedBy { get; set; }
    }
}
