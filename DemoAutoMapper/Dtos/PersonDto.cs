using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAutoMapper.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public int? Age { get; set; }
        public string? Country { get; set; }
        public int? Pincode { get; set; }
    }
}
