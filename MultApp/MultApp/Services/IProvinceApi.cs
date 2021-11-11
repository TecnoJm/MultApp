using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;

using System.Threading.Tasks;

namespace MultApp.Services
{
    public interface IProvinceApi
    {
        [Get("/province/all?api_key={key}")]
        Task<HttpResponseMessage> GetProvincesAsync(string key);
    }
}
