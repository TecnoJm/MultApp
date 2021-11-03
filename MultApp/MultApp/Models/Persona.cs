using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MultApp.Models
{
    public class Persona
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("FirstName")]
        public string Nombre { get; set; }

        [JsonProperty("LastName")]
        public string Apellido { get; set; }


        [JsonProperty("DocumentNumber")]
        public string Documento { get; set; }

        [JsonProperty("DOB")]
        public string FechaDeNacimiento { get; set; }

        [JsonProperty("PictureUrl")]
        public string PictureUrl { get; set; }

    }
}
