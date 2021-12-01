using MultApp.Models;
using MultApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public bool IsEnabled { get; set; } = false;
        public string DocumentoDeIdentidad { get; set; }
        public Usuario Usuario { get; set; }
        public string ConfirmarCotraseña { get; set; }
        Persona Persona { get; set; }
        public IAppUserApiService AppUserApiService { get; }
        public IPersonApiService PersonApiService { get; }
        public ICommand RegisterCommand { get; }
        public ICommand BuscarPersonaCommand { get; }
        public RegisterViewModel(IAlertService alertService, INavigationService navigationService, IAppUserApiService appUserApiService, IPersonApiService personApiService) : base(alertService, navigationService)
        {
            AppUserApiService = appUserApiService;
            PersonApiService = personApiService;
            RegisterCommand = new Command(OnRegister);
            BuscarPersonaCommand = new Command(OnBuscarPersona);
            Usuario = new Usuario();
        }
        private async void OnBuscarPersona()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                IsApiBusy = true;

                IsEnabled = false;

                Persona = await PersonApiService.GetPersonByDocumentAsync(DocumentoDeIdentidad);
                if (Persona == null)
                {
                    await AlertService.AlertAsync("Error", "El documento ingresado no es valido");
                    IsApiBusy = false;
                    return;
                }

                IsEnabled = true;

                IsApiBusy = false;

            });

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

                if (succes)
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
