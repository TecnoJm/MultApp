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
        public Usuario Usuario { get; set; }
        public ICommand ListaMultaCommand { get; }

        public MainScreenConductorViewModel(IAlertService alertService, INavigationService navigationService) : base(alertService, navigationService)
        {
            ListaMultaCommand = new DelegateCommand(OnListaMulta);
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(Config.UsuarioParam, out Usuario usuario))
            {
                Usuario = usuario;
            }
        }

        private async void OnListaMulta()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.NavigateAsync($"{Config.ListaMultaScreen}", new NavigationParameters()
                {
                    {Config.UsuarioParam, Usuario}
                });
            });

        }

    }
}
