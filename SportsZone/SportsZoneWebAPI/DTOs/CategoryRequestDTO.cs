using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.DTOs
{
    public class CategoryRequestDTO
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string CreatedUpdatedBy { get; set; }
    }
}
