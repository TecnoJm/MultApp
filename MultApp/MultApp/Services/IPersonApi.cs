using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;

using System.Threading.Tasks;

namespace MultApp.Services
{
    public interface IPersonApi
    {
        [Get("/person/document/{document}?api_key={key}")]
        Task<HttpResponseMessage> GetPersonByDocumentAsync(string document, string key);

        [Get("/person/id/{id}?api_key={key}")]
        Task<HttpResponseMessage> GetPersonByIdAsync(int id, string key);
    }
}
