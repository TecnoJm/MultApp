using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace MultApp.Models
{
    public class Multa
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("PersonId")]
        public int PersonId { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Paid")]
        public bool Paid { get; set; }

        public string PaidString 
        { 
            get
            {
                if (this.Paid == true) return "Si";
                else return "No";
            }

        }

        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        public string CreatedDateFormatted
        {
            get
            {
                return this.CreatedDate.ToString("dd/MM/yyyy hh:mm:ss");
            }
        }

        [JsonProperty("PenaltyType")]
        public Ley Ley { get; set; }

        [JsonProperty("Province")]
        public Provincia Provincia { get; set; }

    }
}
