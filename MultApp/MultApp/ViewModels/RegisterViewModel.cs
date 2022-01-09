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
    public class RegisterViewModel : BaseViewModel
    {
        public string DocumentoDeIdentidad { get; set; }
        Persona Persona { get; set; }
        public IAppUserApiService AppUserApiService { get; }
        public IPersonApiService PersonApiService { get; }
        public ICommand BuscarPersonaCommand { get; }

        public RegisterViewModel(IAlertService alertService, INavigationService navigationService, IAppUserApiService appUserApiService, IPersonApiService personApiService) : base(alertService, navigationService)
        {
            AppUserApiService = appUserApiService;
            PersonApiService = personApiService;
            BuscarPersonaCommand = new DelegateCommand(OnBuscarPersona);
        }
        private async void OnBuscarPersona()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                IsApiBusy = true;

                if (string.IsNullOrWhiteSpace(DocumentoDeIdentidad))
                {
                    await AlertService.AlertAsync("Error", "No ha ingresado un documento de identidad");
                    IsApiBusy = false;
                    return;
                }
                
                Persona = await PersonApiService.GetPersonByDocumentAsync(DocumentoDeIdentidad);

                if (Persona == null)
                {
                    await AlertService.AlertAsync("Error", "El documento ingresado no es valido");
                    IsApiBusy = false;
                    return;
                }
                bool cuenta = await AppUserApiService.GetUserByPersonId(Persona.Id);

                if(cuenta)
                {
                    await AlertService.AlertAsync("Error", "Ya existe una cuenta con este documento");
                    IsApiBusy = false;
                    return;
                }

                IsApiBusy = false;

                await NavigationService.NavigateAsync($"{Config.RegisterScreen2}", new NavigationParameters()
                {
                    {Config.PersonaParam, Persona}
                });

            });

        }
        

    }
}
