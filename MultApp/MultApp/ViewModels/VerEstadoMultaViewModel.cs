using MultApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Input;
using Xamarin.Forms;
using MultApp.Models;

namespace MultApp.ViewModels
{
    public class VerEstadoMultaViewModel : BaseViewModel
    {

        public Persona Persona { get; set; }
        public ICommand VolverCommand { get; }
        public VerEstadoMultaViewModel(IAlertService alertService, INavigationService navigationService, Persona persona) : base(alertService, navigationService)
        {
            Persona = persona;
            VolverCommand = new Command(OnVolver);
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
