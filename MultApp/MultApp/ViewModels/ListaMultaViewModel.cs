using MultApp.Models;
using MultApp.Services;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModels
{
    public class ListaMultaViewModel : BaseViewModel, INavigatedAware
    {
        public ObservableCollection<Multa> Multas { get; set; }
        public Usuario Usuario  { get; set; }
        public Persona Persona { get; set; }
        public IPenaltyApiService PenaltyApiService { get; }
        public ICommand SelectPenaltyCommand { get; }

        public ListaMultaViewModel(IAlertService alertService, INavigationService navigationService, IPenaltyApiService penaltyApiService) : base(alertService, navigationService)
        {
            PenaltyApiService = penaltyApiService;
            SelectPenaltyCommand = new Command<Multa>(OnSelectPenalty);
            Usuario = null;
            Persona = null;
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            Multas = null;

            if (parameters.TryGetValue(Config.PersonaParam, out Persona persona))
            {
                Persona = persona;

            }

            if (parameters.TryGetValue(Config.UsuarioParam, out Usuario usuario))
            {
                Usuario = usuario;
            }

            if(Persona != null)
            {
                await RunIsBusyTaskAsync(async () =>
                {
                    IsApiBusy = true;
                    Multas = await PenaltyApiService.GetPenailtiesByPersonIdAsync(Persona.Id);
                    IsApiBusy = false;

                });
                return;
            }


            if (Usuario != null)
            {
                await RunIsBusyTaskAsync(async () =>
                {
                    IsApiBusy = true;
                    Multas = await PenaltyApiService.GetPenailtiesByPersonIdAsync(Usuario.Persona.Id);
                    IsApiBusy = false;

                });
                return;
            }



            if (Persona == null && Usuario == null)
            {
                await AlertService.AlertAsync("Error", "Ha ocurrido un error al intentar conseguir la lista de multas");
            }
        }

        private async void OnSelectPenalty(Multa multa)
        {
            await RunIsBusyTaskAsync(async () =>
            {
                if (Persona != null)
                {
                    await NavigationService.NavigateAsync($"{Config.DetallesMultaScreen}", new NavigationParameters()
                    {
                        {Config.PersonaParam, Persona },
                        {Config.MultaParam , multa }
                    });
                }

                if (Usuario != null)
                {
                    await NavigationService.NavigateAsync($"{Config.DetallesMultaScreen}", new NavigationParameters()
                    {
                        {Config.UsuarioParam, Usuario },
                        {Config.MultaParam, multa }
                    });
                }

            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }


    }
}
