using MultApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public interface IAppUserApiService
    {
        Task<Usuario> UserLoginAsync(Usuario usuario);
        Task<bool> UserRegisterAsync(Usuario usuario);
    }
}
