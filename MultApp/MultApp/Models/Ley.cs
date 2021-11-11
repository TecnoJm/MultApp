using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
        public decimal Monto { get; set; }
    }
}
