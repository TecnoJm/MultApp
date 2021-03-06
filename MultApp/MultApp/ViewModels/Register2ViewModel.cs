using MultApp.Models;
using MultApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModels
{
    public class Register2ViewModel : BaseViewModel, IInitialize
    {
        public Usuario Usuario { get; set; }
        public string ConfirmarCotraseña { get; set; }
        public Persona Persona { get; set; }
        public IAppUserApiService AppUserApiService { get; }
        public ICommand RegisterCommand { get; }

        public Register2ViewModel(IAlertService alertService, INavigationService navigationService, IAppUserApiService appUserApiService, IPersonApiService personApiService) : base(alertService, navigationService)
        {
            AppUserApiService = appUserApiService;
            RegisterCommand = new DelegateCommand(OnRegister);
            Usuario = new Usuario();
        }


        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(Config.PersonaParam, out Persona persona))
            {
                Persona = persona;
            }
        }

        private async void OnRegister()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                IsApiBusy = true;
                if (string.IsNullOrWhiteSpace(Usuario.Username) || string.IsNullOrWhiteSpace(Usuario.Email) || string.IsNullOrWhiteSpace(Usuario.Password) || string.IsNullOrWhiteSpace(ConfirmarCotraseña))
                {
                    await AlertService.AlertAsync("Error", "Debe de llenar todos los campos");
                    IsApiBusy = false;
                    return;
                }

                if (Usuario.Password != ConfirmarCotraseña)
                {
                    await AlertService.AlertAsync("Error", "Las constraseñas son distintas");
                    IsApiBusy = false;
                    return;
                }

                Usuario.Persona = Persona;
                bool succes = await AppUserApiService.UserRegisterAsync(Usuario);

                if (!succes)
                {
                    await AlertService.AlertAsync("Error", "Ha ocurrido un error al intentar registrar el usuario");
                    IsApiBusy = false;
                    return;
                }

                await AlertService.AlertAsync("Success", "El usuario ha sido creado con exito. Se la ha enviado un correo para validar su cuenta");
                IsApiBusy = false;
                await NavigationService.GoBackAsync();

            });
        }

    }
}
