using MultApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public class PenaltyApiService : IPenaltyApiService
    {
        ISerializerService SerializerService { get; } = new SerializerService();

        public async Task<bool> CreatePenaltyAsync(Multa multa)
        {
            bool success = false;
            var refitClient = RestService.For<IPenaltyApi>(Config.ApiUrl);

            var response = await refitClient.CreatePenaltyAsync(Config.ApiKey, multa);

            if (response.IsSuccessStatusCode)
            {
                success = true;
            }
            return success;
        }

        public async Task<ObservableCollection<Multa>> GetPenailtiesByPersonIdAsync(int id)
        {
            ObservableCollection<Multa> multas = null;

            var refitClient = RestService.For<IPenaltyApi>(Config.ApiUrl);

            var response = await refitClient.GetPenailtiesByPersonIdAsync(id, Config.ApiKey);

            if (response.IsSuccessStatusCode)
            {
                var responsejson = await response.Content.ReadAsStringAsync();
                multas = SerializerService.Deserialize<ObservableCollection<Multa>>(responsejson);
            }

            return multas;
        }

        public async Task<ObservableCollection<Ley>> GetPenailtyTypesAsync()
        {
            ObservableCollection<Ley> leyes = null;

            var refitClient = RestService.For<IPenaltyApi>(Config.ApiUrl);

            var response = await refitClient.GetPenailtiesAsync(Config.ApiKey);

            if (response.IsSuccessStatusCode)
            {
                var responsejson = await response.Content.ReadAsStringAsync();
                leyes = SerializerService.Deserialize<ObservableCollection<Ley>>(responsejson);
            }

            return leyes;
        }

    }
}
