using MultApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public interface IPenaltyApi
    {
        [Get("/penalty/types/all?api_key={key}")]
        Task<HttpResponseMessage> GetPenailtiesAsync(string key);

        [Get("/penalty/{id}?api_key={key}")]
        Task<HttpResponseMessage> GetPenailtiesByPersonIdAsync(int id, string key);

        [Post("/penalty/create?api_key={key}")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> CreatePenaltyAsync(string key, [Body] Multa multa);
    }
}
