using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MultApp.Models;
using Refit;

namespace MultApp.Services
{
    public interface IAppUserApi
    {
        [Post("/user/register?api_key={key}")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> UserRegisterAsync(string key, [Body] Usuario usuario);

        [Post("/user/login?api_key={key}")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> UserLoginAsync(string key, [Body] Usuario usuario);
    }
}
