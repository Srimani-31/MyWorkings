using System;
using System.Collections.Generic;

#nullable disable

namespace DemoAuthentication.Entities
{
    public partial class UserTable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
    }
}
