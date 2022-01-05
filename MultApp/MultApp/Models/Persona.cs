using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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

        public string NombreCompleto => $"{Nombre} {Apellido}";

        [JsonProperty("DocumentNumber")]
        public string Documento { get; set; }

        [JsonProperty("DOB")]
        public DateTime FechaDeNacimiento { get; set; }

        public string FechaDeNacimientoFormatted
        {
            get
            {
                return this.FechaDeNacimiento.ToString("dd/MM/yyyy");
            }
        }

        [JsonProperty("PictureUrl")]
        public string PictureUrl { get; set; }

    }
}
