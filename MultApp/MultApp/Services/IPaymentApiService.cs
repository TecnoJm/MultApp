using MultApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public interface IPaymentApiService
    {
        Task<bool> PayPenaltyAsync(PaymentInformation paymentInformation);
    }
}
