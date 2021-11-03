using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultApp.Models
{
    public class Multa
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("PersonId")]
        public int PersonId { get; set; }

        [JsonProperty("PenaltyTypeId")]
        public int PenaltyTypeId { get; set; }

        [JsonProperty("ProvinceId")]
        public int ProvinceId { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Paid")]
        public bool Paid { get; set; }
    }
}
