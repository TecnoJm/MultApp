using MultApp.Services;
using MultApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModel
{
    public class MainScreenViewModel : BaseViewModel
    {
        public ICommand VerEstadoCommand { get; }
        public ICommand EscribirMultaCommand { get; }
        public ICommand ListaMultaCommand { get; }
        public MainScreenViewModel(IAlertService alertService, INavigationService navigationService) : base(alertService, navigationService)
        {
            VerEstadoCommand = new Command(OnVerEstado);
            EscribirMultaCommand = new Command(OnEscribirMulta);
            ListaMultaCommand = new Command(OnListaMulta);
        }
        private async void OnVerEstado()
        {
            await NavigationService.NavigationAsync(new VerEstadoMultaScreen(), false);
        }
        private async void OnEscribirMulta()
        {
            await NavigationService.NavigationAsync(new EscribirMultaScreen(), false);

        }
        private async void OnListaMulta()
        {
            await NavigationService.NavigationAsync(new ListaMultaScreen(), false);

        }

    }
}
