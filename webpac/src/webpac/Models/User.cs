using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webpac.Models
{
    public enum UserType { ReadOnly, ReadWrite, Admin }

    public class User
    {
        public UserType Type { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
