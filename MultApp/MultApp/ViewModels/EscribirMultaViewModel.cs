using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Data.SqlClient;
using Xamarin.Forms;
using MultApp.Services;
using MultApp.Models;

namespace MultApp.ViewModels
{
    public class EscribirMultaViewModel : BaseViewModel
    {
        public ObservableCollection<Ley> Leyes { get; set; }
        public ObservableCollection<Provincia> Provincias { get; set; }
        public Ley LeyInfringida { get; set; }
        public Provincia Provincia { get; set; }
        public IPenaltyApiService PenaltyApiService { get; }
        public ICommand RegistrarInfraccionCommand { get; }
        public ICommand VolverCommand { get; }
        public Persona Persona { get; set; }
        public Multa Multa { get; set; } = new Multa();
        public EscribirMultaViewModel(IAlertService alertService, INavigationService navigationService, IPenaltyApiService penaltyApiService, Persona persona) : base(alertService, navigationService)
        {
            PenaltyApiService = penaltyApiService;
            Persona = persona;
            Leyes = Config.Leyes;
            Provincias = Config.Provincias;
            LeyInfringida = new Ley();
            RegistrarInfraccionCommand = new Command(OnRegistrarInfraccion);
            VolverCommand = new Command(OnVolver);
        }

        private async void OnRegistrarInfraccion()
        {
            IsApiBusy = true;
            await RunIsBusyTaskAsync(async () =>
            {
                if (!string.IsNullOrWhiteSpace(Multa.Description) && !string.IsNullOrWhiteSpace(Multa.Address) && !string.IsNullOrWhiteSpace(LeyInfringida.Descripcion) && LeyInfringida != null && Provincia != null)
                {
                    Multa.PersonId = Persona.Id;
                    Multa.PenaltyTypeId = LeyInfringida.Id;
                    Multa.ProvinceId = Provincia.Id;
                    bool success = await PenaltyApiService.CreatePenaltyAsync(Multa);
                    if (success)
                    {
                        await AlertService.AlertAsync("Exito", "Multa creada con exito");
                        Multa = new Multa();
                    }
                    else
                    {
                        await AlertService.AlertAsync("Error", "Ha ocurrido un error al intentar crear la multa");
                    }
                }
                else
                {
                    await AlertService.AlertAsync("Error", "Debe de llenar todos los campos");
                }
            });
            IsApiBusy = false;
        }

        private async void OnVolver()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.NavigationPopAsync();

            });
        }
    }
}
