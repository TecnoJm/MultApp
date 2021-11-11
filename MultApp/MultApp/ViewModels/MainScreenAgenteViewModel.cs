using MultApp.Models;
using MultApp.Services;
using MultApp.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModels
{
    public class MainScreenAgenteViewModel : BaseViewModel
    {
        public bool IsEnabled { get; set; } = false;
        public string DocumentoDeIdentidad { get; set; }
        public Persona Persona { get; set; }
        public IPersonApiService PersonApiService { get; set; }
        public ICommand VerEstadoCommand { get; }
        public ICommand EscribirMultaCommand { get; }
        public ICommand BuscarPersona { get; }
        public ICommand LogoutCommand { get; }



        public MainScreenAgenteViewModel(IAlertService alertService, INavigationService navigationService, IPersonApiService personApiService) : base(alertService, navigationService)
        {
            VerEstadoCommand = new Command(OnVerEstado);
            EscribirMultaCommand = new Command(OnEscribirMulta);
            BuscarPersona = new Command(OnBuscarPersona);
            LogoutCommand = new Command(OnLogout);
            PersonApiService = personApiService;
        }
        private async void OnVerEstado()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.NavigationAsync(new VerEstadoMultaScreen(Persona), false);
            });
        }
        private async void OnEscribirMulta()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.NavigationAsync(new EscribirMultaScreen(Persona), false);
            });

        }

        private async void OnBuscarPersona()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                IsApiBusy = true;

                IsEnabled = false;
                Persona = await PersonApiService.GetPersonByDocumentAsync(DocumentoDeIdentidad);
                if (Persona == null)
                {
                    await AlertService.AlertAsync("Error", "El documento ingresado no es valido");
                }
                else
                {
                    await AlertService.AlertAsync("Success", $"Persona encontrada: {Persona.Nombre} {Persona.Apellido}");
                    IsEnabled = true;
                }
                IsApiBusy = false;

            });

        }


        private async void OnLogout()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.NavigationPopAsync();
            });

        }

    }
}
