using MultApp.Models;
using MultApp.Services;
using MultApp.Views;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModels
{
    public class MainScreenAgenteViewModel : BaseViewModel, INavigatedAware
    {
        public bool IsEnabled { get; set; } = false;
        public string DocumentoDeIdentidad { get; set; }
        public Persona Persona { get; set; }

        public IPersonApiService PersonApiService { get; }
        public  IPenaltyApiService PenaltyApiService { get; }
        public  IProvinceApiService ProvinceApiService { get; }

        public ICommand VerEstadoCommand { get; }
        public ICommand EscribirMultaCommand { get; }
        public ICommand BuscarPersona { get; }
        public ICommand LogoutCommand { get; }



        public MainScreenAgenteViewModel(IAlertService alertService, INavigationService navigationService, IPersonApiService personApiService, IPenaltyApiService penaltyApiService, IProvinceApiService provinceApiService) : base(alertService, navigationService)
        {
            PersonApiService = personApiService;
            PenaltyApiService = penaltyApiService;
            ProvinceApiService = provinceApiService;
            VerEstadoCommand = new Command(OnVerEstado);
            EscribirMultaCommand = new Command(OnEscribirMulta);
            BuscarPersona = new Command(OnBuscarPersona); 
            LogoutCommand = new Command(OnLogout);
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(Config.UsuarioParam, out Usuario usuario))
            {
                Persona = usuario.Persona;
            }

            Config.Leyes = await PenaltyApiService.GetPenailtyTypesAsync();
            Config.Provincias = await ProvinceApiService.GetProvincesAsync();
        }

        private async void OnVerEstado()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.NavigateAsync($"{Config.VerEstadoMultaScreen}", new NavigationParameters() 
                {
                    {Config.PersonaParam, Persona }
                });
            });
        }
        private async void OnEscribirMulta()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.NavigateAsync($"{Config.EscribirMultaScreen}", new NavigationParameters()
                {
                    {Config.PersonaParam, Persona }
                });
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
                    IsApiBusy = false;
                    return;
                }

                IsEnabled = true;

                IsApiBusy = false;


            });

        }
        private async void OnLogout()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.GoBackAsync();
            });

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }


    }
}
