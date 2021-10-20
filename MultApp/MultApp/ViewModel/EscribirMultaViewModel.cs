using MultApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModel
{
    public class EscribirMultaViewModel : BaseViewModel
    {
        public ObservableCollection<string> LeyInfringida { get; set; }
        public ICommand VolverCommand { get; }
        public EscribirMultaViewModel(IAlertService alertService, INavigationService navigationService) : base(alertService, navigationService)
        {
            VolverCommand = new Command(OnVolver);
            LeyInfringida = new ObservableCollection<string>();
            for (int i = 0; i < 6; i++)
            {
                LeyInfringida.Add($"Item {i}");
            }
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
