using MultApp.Models;
using MultApp.Services;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModels
{
    public class ListaMultaViewModel : BaseViewModel, INavigatedAware
    {
        public ObservableCollection<Multa> Multas { get; set; }
        public Persona Persona { get; set; }
        public IPenaltyApiService PenaltyApiService { get; }
        public ICommand TappedCommand { get; }

        public ListaMultaViewModel(IAlertService alertService, INavigationService navigationService, IPenaltyApiService penaltyApiService) : base(alertService, navigationService)
        {
            PenaltyApiService = penaltyApiService;
            TappedCommand = new Command<Multa>(OnTapped);
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(Config.PersonaParam, out Persona persona))
            {
                Persona = persona;
            }

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

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }


    }
}
