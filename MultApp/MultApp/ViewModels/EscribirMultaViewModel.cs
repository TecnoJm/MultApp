using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Data.SqlClient;
using Xamarin.Forms;
using MultApp.Services;
using MultApp.Models;
using Prism.Navigation;
using System.Threading.Tasks;

namespace MultApp.ViewModels
{
    public class EscribirMultaViewModel : BaseViewModel, IInitialize
    {
        public ObservableCollection<Ley> Leyes { get; set; }
        public ObservableCollection<Provincia> Provincias { get; set; }
        public Provincia Provincia { get; set; }

        public IProvinceApiService ProvinceApiService { get; }
        public IPenaltyApiService PenaltyApiService { get; }
        public ICommand RegistrarInfraccionCommand { get; }
        public ICommand VolverCommand { get; }
        public Persona Persona { get; set; }
        public Multa Multa { get; set; }

        public EscribirMultaViewModel(IAlertService alertService, INavigationService navigationService, IPenaltyApiService penaltyApiService, IProvinceApiService provinceApiService) : base(alertService, navigationService)
        {
            PenaltyApiService = penaltyApiService;
            ProvinceApiService = provinceApiService;
            Leyes = Config.Leyes;
            Provincias = Config.Provincias;
            Multa = new Multa();
            RegistrarInfraccionCommand = new Command(OnRegistrarInfraccion);
            VolverCommand = new Command(OnVolver);
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(Config.PersonaParam, out Persona persona))
            {
                Persona = persona;
            }
        }

        private async void OnRegistrarInfraccion()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                IsApiBusy = true;
                if (string.IsNullOrWhiteSpace(Multa.Description) || string.IsNullOrWhiteSpace(Multa.Address))
                {
                    await AlertService.AlertAsync("Error", "Debe de llenar todos los campos");
                    IsApiBusy = false;
                    return;
                }


                Multa.PersonId = Persona.Id;
                bool success = await PenaltyApiService.CreatePenaltyAsync(Multa);
                if (!success)
                {
                    await AlertService.AlertAsync("Error", "Ha ocurrido un error al intentar crear la multa");
                    IsApiBusy = false;
                    return;
                }

                await AlertService.AlertAsync("Exito", "Multa creada con exito");
                await NavigationService.GoBackAsync();
                
                IsApiBusy = false;
            });
        }

        private async void OnVolver()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.GoBackAsync();
            });
        }


    }
}
