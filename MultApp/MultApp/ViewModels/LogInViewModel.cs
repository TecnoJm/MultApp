using System;
using System.Data.SqlClient;
using System.Windows.Input;
using Xamarin.Forms;
using MultApp.Views;
using MultApp.Services;
using Xamarin.Essentials;
using MultApp.Models;
using Newtonsoft.Json;

namespace MultApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Action DisplayInvalidLoginPrompt;
        public string Username { get; set; }
        public string Password { get; set; }
        public Usuario Usuario { get; set; }
        IAppUserApiService AppUserApiService { get; }
        public ICommand SubmitCommand { protected set; get; }

        public LoginViewModel(IAlertService alertService, INavigationService navigationService, IAppUserApiService appUserApiService) : base(alertService, navigationService)
        {
            AppUserApiService = appUserApiService;
            SubmitCommand = new Command(OnSubmit);
        }
        public async void OnSubmit()
        {
            IsApiBusy = true;

            await RunIsBusyTaskAsync(async () =>
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    Usuario = await AppUserApiService.UserLoginAsync(new Usuario() { Username = Username, Password = Password });
                    if (Usuario == null)
                    {
                        await AlertService.AlertAsync("Error", "Usuario o Contraseña Invalidos");
                    }
                    else
                    {
                        await AlertService.AlertAsync("!", "Bienvenido: " + Usuario.Username);
                        await NavigationService.NavigationAsync(new MainScreen(), false);
                    }
                }
                else
                {
                    await AlertService.AlertAsync("No internet connection", "No internet connection detected");
                }

            });
            IsApiBusy = false;

        }
    }
}
