using MultApp.Models;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace MultApp.Services
{
    public interface IPersonApiService
    {
        Task<Persona> GetPersonByDocumentAsync(string documento);
        Task<Persona> GetPersonByIdAsync(int id);
    }
}
