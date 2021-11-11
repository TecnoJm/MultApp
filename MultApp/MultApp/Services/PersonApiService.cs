using MultApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public class PersonApiService : IPersonApiService
    {
        ISerializerService SerializerService { get; } = new SerializerService();

        public async Task<Persona> GetPersonByDocumentAsync(string documento)
        {
            Persona persona = null;

            var refitClient = RestService.For<IPersonApi>(Config.ApiUrl);

            var response = await refitClient.GetPersonByDocumentAsync(documento, Config.ApiKey);

            if (response.IsSuccessStatusCode)
            {
                var responsejson = await response.Content.ReadAsStringAsync();
                persona = SerializerService.Deserialize<Persona>(responsejson);
            }

            return persona;
        }

        public async Task<Persona> GetPersonByIdAsync(int id)
        {
            Persona persona = null;

            var refitClient = RestService.For<IPersonApi>(Config.ApiUrl);

            var response = await refitClient.GetPersonByIdAsync(id, Config.ApiKey);

            if (response.IsSuccessStatusCode)
            {
                var responsejson = await response.Content.ReadAsStringAsync();
                persona = SerializerService.Deserialize<Persona>(responsejson);
            }

            return persona;
        }
    }
}
