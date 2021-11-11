using System;
using System.Data.SqlClient;
using System.Windows.Input;
using Xamarin.Forms;
using MultApp.Views;
using MultApp.Services;
using Xamarin.Essentials;
using MultApp.Models;

namespace MultApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Action DisplayInvalidLoginPrompt;
        public string Username { get; set; }
        public string Password { get; set; }
        public Usuario Usuario { get; set; }
        IAppUserApiService AppUserApiService { get; }
        IPersonApiService PersonApiService { get; }
        public ICommand SubmitCommand { protected set; get; }

        public LoginViewModel(IAlertService alertService, INavigationService navigationService, IAppUserApiService appUserApiService, IPersonApiService personApiService) : base(alertService, navigationService)
        {
            AppUserApiService = appUserApiService;
            PersonApiService = personApiService;
            SubmitCommand = new Command(OnSubmit);
        }
        public async void OnSubmit()
        {

            await RunIsBusyTaskAsync(async () =>
            {
                IsApiBusy = true;

                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    Usuario = await AppUserApiService.UserLoginAsync(new Usuario() { Username = Username, Password = Password });
                    if (Usuario == null)
                    {
                        await AlertService.AlertAsync("Error", "Usuario o Contraseña Invalidos");
                    }
                    else
                    {
                        Username = null;
                        Password = null;

                        switch (Usuario.UserTypeId)
                        {
                            case UserType.Agente:
                                await NavigationService.NavigationAsync(new MainScreenAgente(), true);
                                break;

                            case UserType.Conductor:
                                await NavigationService.NavigationAsync(new MainScreenConductor(await PersonApiService.GetPersonByIdAsync(Usuario.PersonId)), true);
                                break;

                        }
                    }
                }
                else
                {
                    await AlertService.AlertAsync("No internet connection", "No internet connection detected");
                }
                IsApiBusy = false;

            });

        }
    }
}
