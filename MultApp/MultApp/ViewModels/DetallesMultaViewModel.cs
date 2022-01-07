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
    public class DetallesMultaViewModel : BaseViewModel, IInitialize
    {
        public Multa Multa { get; set; }
        public Persona Persona { get; set; }
        public Usuario Usuario { get; set; }
        public bool IsPaymentEnabled { get; set; } = true;
        public ICommand PagarInfraccionCommand { get; }
        public DetallesMultaViewModel(IAlertService alertService, INavigationService navigationService) : base(alertService, navigationService)
        {
            PagarInfraccionCommand = new DelegateCommand(OnPagarInfraccion);
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(Config.MultaParam, out Multa multa))
            {
                Multa = multa;
                if (Multa.Paid)
                {
                    IsPaymentEnabled = false;
                }
            }

            if (parameters.TryGetValue(Config.PersonaParam, out Persona persona))
            {
                Persona = persona;
                IsPaymentEnabled = false;
            }

            if (parameters.TryGetValue(Config.UsuarioParam, out Usuario usuario))
            {
                Usuario = usuario;
                Persona = Usuario.Persona;
            }
        }

        private async void OnPagarInfraccion()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.NavigateAsync($"{Config.PagoScreen}", new NavigationParameters()
                {
                    {Config.MultaParam, Multa }
                });
            });
        }
    }
}
