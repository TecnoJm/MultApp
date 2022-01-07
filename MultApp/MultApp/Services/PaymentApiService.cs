using MultApp.Models;
using Refit;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public class PaymentApiService : IPaymentApiService
    {
        public async Task<bool> PayPenaltyAsync(PaymentInformation paymentInformation)
        {
            string stripeTokenId = CreateToken(paymentInformation);

            PaymentModel paymentModel = new PaymentModel() { Token = stripeTokenId, Amount = paymentInformation.Multa.Ley.Precio, Multa = paymentInformation.Multa };

            bool success = false;

            var refitClient = RestService.For<IPaymentApi>(Config.ApiUrl);

            var response = await refitClient.PayAsync(Config.ApiKey, paymentModel);


            if (response.IsSuccessStatusCode)
            {
                success = true;
            }

            return success;

        }

        public string CreateToken(PaymentInformation paymentInformation)
        {
            StripeConfiguration.ApiKey = "pk_test_51J4Vq5JywCuYaxUHsP3Ix9k7GyhkfKxX7j2UXJQDtjhInhGTn20Np6TiO4GBr5wbIwayFOpfndUVdHfkK5lUTHYF00OyOTKnpS";

            var tokenOptions = new TokenCreateOptions()
            {
                Card = new TokenCardOptions()
                {
                    Number = paymentInformation.CardNumber,
                    ExpYear = paymentInformation.ExpYear,
                    ExpMonth = paymentInformation.ExpMonth,
                    Cvc = paymentInformation.CardCvv
                }
            };

            var tokenService = new TokenService();
            Token stripeToken = tokenService.Create(tokenOptions);

            return stripeToken.Id;
        }
    }

  
}
