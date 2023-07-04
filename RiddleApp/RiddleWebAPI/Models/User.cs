using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace RiddleWebAPI.Models
{
    public partial class User
    {
        public User()
        {
            Riddles = new HashSet<Riddle>();
        }

        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public virtual ICollection<Riddle> Riddles { get; set; }
    }
}
