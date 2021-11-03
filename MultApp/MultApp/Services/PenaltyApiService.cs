using MultApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public class PenaltyApiService : IPenaltyApiService
    {
        ISerializerService SerializerService { get; } = new SerializerService();

        public async Task<bool> CreatePenaltyAsync(Multa multa)
        {
            bool success = false;
            var refitClient = RestService.For<IPenaltyApi>("http://192.168.192.1:3000/api");

            var response = await refitClient.CreatePenaltyAsync(Config.ApiKey, multa);

            if (response.IsSuccessStatusCode)
            {
                success = true;
            }
            return success;
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
