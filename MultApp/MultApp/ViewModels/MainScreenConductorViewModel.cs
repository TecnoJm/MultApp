using MultApp.Models;
using MultApp.Services;
using MultApp.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MultApp.ViewModels
{
    public class MainScreenConductorViewModel : BaseViewModel, IInitialize
    {
        public Persona Persona { get; set; }
        public ICommand ListaMultaCommand { get; }
        public ICommand LogoutCommand { get; }

        public MainScreenConductorViewModel(IAlertService alertService, INavigationService navigationService) : base(alertService, navigationService)
        {
            ListaMultaCommand = new DelegateCommand(OnListaMulta);
            LogoutCommand = new DelegateCommand(OnLogout);
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(Config.UsuarioParam, out Usuario usuario))
            {
                Persona = usuario.Persona;
            }
        }

        private async void OnListaMulta()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.NavigateAsync($"{Config.ListaMultaScreen}", new NavigationParameters()
                {
                    {Config.PersonaParam, Persona}
                });
            });

        }

        private async void OnLogout()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.GoBackToRootAsync();
            });

        }
    }
}
