using MultApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public interface IPaymentApi
    {
        [Post("/penalty/pay?api_key={key}")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> PayAsync(string key, [Body] PaymentModel paymentModel);
    }
}
