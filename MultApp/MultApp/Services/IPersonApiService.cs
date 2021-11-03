using MultApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public interface IPersonApiService
    {
        Task<Persona> GetPersonAsync(string documento);
    }
}
