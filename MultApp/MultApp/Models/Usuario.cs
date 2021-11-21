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
        [JsonProperty("personId")]
        public int PersonId { get; set; }

        [JsonProperty("userTypeId")]
        public UserType UserTypeId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

    }
}
