using MultApp.Models;
using MultApp.Services;
using MultApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModels
{
    public class MainScreenViewModel : BaseViewModel
    {
        public bool IsEnabled { get; set; } = false;
        public string DocumentoDeIdentidad { get; set; }
        public Persona Persona { get; set; }
        public IPersonApiService PersonApiService { get; set; }
        public ICommand VerEstadoCommand { get; }
        public ICommand EscribirMultaCommand { get; }
        public ICommand ListaMultaCommand { get; }
        public ICommand BuscarPersona { get; }



        public MainScreenViewModel(IAlertService alertService, INavigationService navigationService, IPersonApiService personApiService) : base(alertService, navigationService)
        {
            VerEstadoCommand = new Command(OnVerEstado);
            EscribirMultaCommand = new Command(OnEscribirMulta);
            ListaMultaCommand = new Command(OnListaMulta);
            BuscarPersona = new Command(OnBuscarPersona);
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
        private async void OnListaMulta()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.NavigationAsync(new ListaMultaScreen(), false);
            });

        }
        private async void OnBuscarPersona()
        {
            IsApiBusy = true;
            await RunIsBusyTaskAsync(async () =>
            {
                IsEnabled = false;
                Persona = await PersonApiService.GetPersonAsync(DocumentoDeIdentidad);
                if (Persona == null)
                {
                    await AlertService.AlertAsync("Error", "El documento ingresado no es valido");
                }
                else
                {
                    await AlertService.AlertAsync("Success", $"Persona encontrada: {Persona.Nombre} {Persona.Apellido}");
                    IsEnabled = true;
                }
            });
            IsApiBusy = false;

        }

    }
}
