using System;
using System.Collections.Generic;

#nullable disable

namespace Coffee_Management_Software.Models
{
    public partial class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int IdEmployee { get; set; }
        public bool? Status { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
