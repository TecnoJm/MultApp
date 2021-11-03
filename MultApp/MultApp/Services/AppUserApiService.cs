using MultApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public class AppUserApiService : IAppUserApiService
    {
        ISerializerService SerializerService { get; } = new SerializerService();
        public async Task<Usuario> UserLoginAsync(Usuario usuario)
        {
            Usuario user = null;


            var refitClient = RestService.For<IAppUserApi>(Config.ApiUrl);

            var response = await refitClient.UserLoginAsync(Config.ApiKey, usuario);

            //var client = new HttpClient();

            //var content = new StringContent(usuario, Encoding.UTF8, "application/json");

            //var response = await client.PostAsync($"login?api_key={ApiKey}", content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responsejson = await response.Content.ReadAsStringAsync();
                user = SerializerService.Deserialize<Usuario>(responsejson);
            }

            return user;
        }

    }
}








