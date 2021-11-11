using MultApp.Models;
using MultApp.Services;
using MultApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModels
{
    public class MainScreenConductorViewModel : BaseViewModel
    {
        public IPenaltyApiService PenaltyApiService { get; }
        public Persona Persona { get; }
        public ICommand ListaMultaCommand { get; }
        public ICommand LogoutCommand { get; }

        public MainScreenConductorViewModel(IAlertService alertService, INavigationService navigationService, IPenaltyApiService penaltyApiService, Persona persona) : base(alertService, navigationService)
        {
            Persona = persona;
            PenaltyApiService = penaltyApiService;
            ListaMultaCommand = new Command(OnListaMulta);
            LogoutCommand = new Command(OnLogout);
        }
        private async void OnListaMulta()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.NavigationAsync(new ListaMultaScreen(Persona), false);
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
