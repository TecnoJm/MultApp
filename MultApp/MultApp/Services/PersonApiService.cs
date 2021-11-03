using MultApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public class PersonApiService : IPersonApiService
    {
        ISerializerService SerializerService { get; } = new SerializerService();

        public async Task<Persona> GetPersonAsync(string documento)
        {
            Persona persona = null;

            var refitClient = RestService.For<IPersonApi>(Config.ApiUrl);

            var response = await refitClient.GetPersonAsync(documento, Config.ApiKey);

            if (response.IsSuccessStatusCode)
            {
                var responsejson = await response.Content.ReadAsStringAsync();
                persona = SerializerService.Deserialize<Persona>(responsejson);
            }

            return persona;
        }
    }
}
