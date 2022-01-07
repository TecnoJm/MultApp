using MultApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MultApp.Models;
using Prism;
using Prism.Unity;
using Prism.Ioc;
using MultApp.Views;
using MultApp.ViewModels;
using Xamarin.Forms;

namespace MultApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{Config.NavigationPage}/{Config.LoginScreen}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterForNavigation<NavigationPage>(Config.NavigationPage);
            containerRegistry.RegisterForNavigation<LogIn, LoginViewModel>(Config.LoginScreen);
            containerRegistry.RegisterForNavigation<RegisterScreen, RegisterViewModel>(Config.RegisterScreen);
            containerRegistry.RegisterForNavigation<RegisterScreen2, Register2ViewModel>(Config.RegisterScreen2);
            containerRegistry.RegisterForNavigation<MainScreenAgente, MainScreenAgenteViewModel>(Config.MainScreenAgente);
            containerRegistry.RegisterForNavigation<MainScreenConductor, MainScreenConductorViewModel>(Config.MainScreenConductor);
            containerRegistry.RegisterForNavigation<ListaMultaScreen, ListaMultaViewModel>(Config.ListaMultaScreen);
            containerRegistry.RegisterForNavigation<EscribirMultaScreen, EscribirMultaViewModel>(Config.EscribirMultaScreen);
            containerRegistry.RegisterForNavigation<VerEstadoMultaScreen, VerEstadoMultaViewModel>(Config.VerEstadoMultaScreen);
            containerRegistry.RegisterForNavigation<DetallesMultaScreen, DetallesMultaViewModel>(Config.DetallesMultaScreen);
            containerRegistry.RegisterForNavigation<PagoScreen, PagoViewModel>(Config.PagoScreen);


            containerRegistry.Register<IAppUserApiService, AppUserApiService>();
            containerRegistry.Register<IPenaltyApiService, PenaltyApiService>();
            containerRegistry.Register<IPersonApiService, PersonApiService>();
            containerRegistry.Register<IPaymentApiService, PaymentApiService>();
            containerRegistry.Register<IProvinceApiService, ProvinceApiService>();
            containerRegistry.Register<IAlertService, AlertService>();
        }
       
    }
}
