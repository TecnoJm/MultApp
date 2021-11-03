using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MultApp.Models
{
    public class Ley
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Law")]
        public string NumeroLey { get; set; }

        [JsonProperty("Description")]
        public string Descripcion { get; set; }

        [JsonProperty("Price")]
        public int Precio { get; set; }
    }
}
