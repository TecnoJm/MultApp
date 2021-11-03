using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public interface IPersonApi
    {
        [Get("/person/{document}?api_key={key}")]
        Task<HttpResponseMessage> GetPersonAsync(string document, string key);
    }
}
