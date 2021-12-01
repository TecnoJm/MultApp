using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;


namespace MultApp.Models
{
    public enum UserType
    {
        Agente = 1,
        Conductor = 2
    }
    public class Usuario
    {

        [JsonProperty("UserTypeId")]
        public UserType UserTypeId { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Enabled")]
        public bool Activo { get; set; }

        [JsonProperty("Person")]
        public Persona Persona { get; set; }

    }
}
