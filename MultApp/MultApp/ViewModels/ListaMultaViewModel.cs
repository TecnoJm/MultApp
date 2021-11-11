using MultApp.Models;
using MultApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModels
{
    public class ListaMultaViewModel : BaseViewModel
    {
        public ObservableCollection<Multa> Multas { get; set; }
        public Persona Persona { get; }
        public IPenaltyApiService PenaltyApiService { get; }
        public ICommand TappedCommand { get; }
        public ListaMultaViewModel(IAlertService alertService, INavigationService navigationService, IPenaltyApiService penaltyApiService, Persona persona) : base(alertService, navigationService)
        {
            PenaltyApiService = penaltyApiService;
            Persona = persona;
            GetMultas();
            TappedCommand = new Command<Multa>(OnTapped);
        }
        private async void GetMultas()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                IsApiBusy = true;
                Multas = await PenaltyApiService.GetPenailtiesByPersonIdAsync(Persona.Id);
                IsApiBusy = false;

            });
        }

        private async void OnTapped(Multa multa)
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await AlertService.AlertAsync("!", multa.Description);
            });
        }
    }
}
