using MultApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public class AppUserApiService : IAppUserApiService
    {
        ISerializerService SerializerService { get; } = new SerializerService();
        public async Task<Usuario> UserLoginAsync(Usuario usuario)
        {

            var refitClient = RestService.For<IAppUserApi>(Config.ApiUrl);

            var response = await refitClient.UserLoginAsync(Config.ApiKey, usuario);

            if (response.IsSuccessStatusCode)
            {
                var responsejson = await response.Content.ReadAsStringAsync();
                usuario = SerializerService.Deserialize<Usuario>(responsejson);
            }

            //switch (response.StatusCode)
            //{
            //    case System.Net.HttpStatusCode.Accepted:
            //        break;

            //    case System.Net.HttpStatusCode.Unauthorized:
            //        break;
            //    default:
            //        break;
            //}

            return usuario;
        }

        public async Task<bool> UserRegisterAsync(Usuario usuario)
        {
            bool success = false;

            var refitClient = RestService.For<IAppUserApi>(Config.ApiUrl);

            var response = await refitClient.UserRegisterAsync(Config.ApiKey, usuario);


            if (response.IsSuccessStatusCode)
            {
                success = true;
            }

            return success;
        }
    }
}








