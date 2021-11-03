using System;
using System.Collections.Generic;
using System.Text;

namespace MultApp.Models
{
    public enum UserType
    {
        Oficial = 1,
        Conductor = 2
    }
    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserType UserTypeId { get; set; }
    }
}
