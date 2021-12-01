using System.Windows.Input;
using MultApp.Services;
using MultApp.Models;
using Prism.Navigation;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace MultApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Usuario Usuario { get; set; }
        public IAppUserApiService AppUserApiService { get; }
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel(IAlertService alertService, INavigationService navigationService, IAppUserApiService appUserApiService) : base(alertService, navigationService)
        {
            AppUserApiService = appUserApiService;
            LoginCommand = new Command(OnLogin);
            RegisterCommand = new Command(OnRegister);

            Usuario = new Usuario();
        }

        private async void OnLogin()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                IsApiBusy = true;

                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await AlertService.AlertAsync("No internet connection", "No internet connection detected");
                    IsApiBusy = false;

                    return;
                }
                Usuario = await AppUserApiService.UserLoginAsync(Usuario);

                if (Usuario.Persona == null)
                {
                    await AlertService.AlertAsync("Error", "Usuario o Contraseña incorrecto");
                    IsApiBusy = false;
                    return;
                }

                if (!Usuario.Activo)
                {
                    await AlertService.AlertAsync("Error", "Necesita activar este usuario");
                    IsApiBusy = false;
                    return;
                }


                switch (Usuario.UserTypeId)
                {
                    case UserType.Agente:
                        await NavigationService.NavigateAsync($"{Config.MainScreenAgente}", new NavigationParameters()
                        {
                            {Config.UsuarioParam, Usuario}
                        });
                        break;

                    case UserType.Conductor:
                        await NavigationService.NavigateAsync($"{Config.MainScreenConductor}", new NavigationParameters()
                        {
                            {Config.UsuarioParam, Usuario}
                        });
                        break;
                }
                IsApiBusy = false;

            });

        }

        private async void OnRegister() 
        {
            await NavigationService.NavigateAsync($"{Config.RegisterScreen}");
        }

    }
}
