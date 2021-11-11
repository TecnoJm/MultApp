using MultApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public class ProvinceApiService : IProvinceApiService
    {
        ISerializerService SerializerService { get; } = new SerializerService();

        public async Task<ObservableCollection<Provincia>> GetProvincesAsync()
        {
            ObservableCollection<Provincia> provincias = null;

            var refitClient = RestService.For<IProvinceApi>(Config.ApiUrl);

            var response = await refitClient.GetProvincesAsync(Config.ApiKey);

            if (response.IsSuccessStatusCode)
            {
                var responsejson = await response.Content.ReadAsStringAsync();
                provincias = SerializerService.Deserialize<ObservableCollection<Provincia>>(responsejson);
            }

            return provincias;
        }
    }
}
