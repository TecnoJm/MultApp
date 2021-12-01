using MultApp.Services;
using System.Windows.Input;
using Xamarin.Forms;
using MultApp.Models;
using Prism.Navigation;

namespace MultApp.ViewModels
{
    public class VerEstadoMultaViewModel : BaseViewModel, IInitialize
    {
        public Persona Persona { get; set; }
        public ICommand VolverCommand { get; }
        public VerEstadoMultaViewModel(IAlertService alertService, INavigationService navigationService, Persona persona) : base(alertService, navigationService)
        {
            Persona = persona;
            VolverCommand = new Command(OnVolver);
        }
        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(Config.PersonaParam, out Persona persona))
            {
                Persona = persona;
            }
        }

        private async void OnVolver()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.GoBackAsync();
            });
        }
    }
}
