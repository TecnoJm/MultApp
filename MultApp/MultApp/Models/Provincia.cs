using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MultApp.Models
{
    public class Provincia
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Description")]
        public string Descripcion { get; set; }
    }
}
