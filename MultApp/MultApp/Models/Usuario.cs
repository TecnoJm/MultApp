using System;
using System.Collections.Generic;


namespace MultApp.Models
{
    public enum UserType
    {
        Oficial = 1,
        Conductor = 2
    }
    public class Usuario
    {
        public int PersonId { get; set; }
        public UserType UserTypeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
