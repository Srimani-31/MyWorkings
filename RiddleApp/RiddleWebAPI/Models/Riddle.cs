using System;
using System.Collections.Generic;

#nullable disable

namespace RiddleWebAPI.Models
{
    public partial class Riddle
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string RiddleQuestion { get; set; }
        public string RiddleAnswer { get; set; }

        public virtual User UsernameNavigation { get; set; }
    }
}
