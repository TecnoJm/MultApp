using MultApp.Models;
using MultApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MultApp.ViewModels
{
    public class PagoViewModel : BaseViewModel, IInitialize
    {
        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public string CardExpirationDate { get; set; }
        public PaymentInformation PaymentInformation { get; set; }
        public Multa Multa { get; set; }
        public ICommand PagarCommand { get; }
        public IPaymentApiService PaymentApiService { get; }

        public PagoViewModel(IAlertService alertService, INavigationService navigationService, IPaymentApiService paymentApiService) : base(alertService, navigationService)
        {
            PaymentApiService = paymentApiService;
            PagarCommand = new DelegateCommand(OnPagar);
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(Config.MultaParam, out Multa multa))
            {
                Multa = multa;
            }
        }

        private async void OnPagar()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                IsApiBusy = true;
                if (string.IsNullOrWhiteSpace(CardNumber) || string.IsNullOrWhiteSpace(CardCvv) || string.IsNullOrWhiteSpace(CardExpirationDate))
                {
                    await AlertService.AlertAsync("Error", "Debe de llenar todos los campos");
                    IsApiBusy = false;
                    return;
                }
                PaymentInformation = new PaymentInformation() { CardNumber = CardNumber, CardExpirationDate = CardExpirationDate, CardCvv = CardCvv, Multa = Multa};

                bool success = await PaymentApiService.PayPenaltyAsync(PaymentInformation);

                if (!success)
                {
                    await AlertService.AlertAsync("Error", "Ha ocurrido un error al intentar pagar la multa");
                    IsApiBusy = false;
                    return;
                }

                IsApiBusy = false;
                await AlertService.AlertAsync("Exito", "El pago se ha realizado con exito");
               
                await NavigationService.NavigateAsync("../../");

            });
        }
    }
}
