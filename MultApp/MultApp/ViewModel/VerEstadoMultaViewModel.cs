using MultApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModel
{
    public class VerEstadoMultaViewModel : BaseViewModel
    {
        public ICommand VolverCommand { get; }
        public VerEstadoMultaViewModel(IAlertService alertService, INavigationService navigationService) : base(alertService, navigationService)
        {
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
