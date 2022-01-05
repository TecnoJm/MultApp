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

        public ICommand ListaMultaCommand { get; }
        public VerEstadoMultaViewModel(IAlertService alertService, INavigationService navigationService, Persona persona) : base(alertService, navigationService)
        {
            Persona = persona;
            ListaMultaCommand = new Command(OnListaMulta);
        }
        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(Config.PersonaParam, out Persona persona))
            {
                Persona = persona;
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

    }
}
