using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MultApp.Views;
using MultApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MultApp.Models;

namespace MultApp
{
    public partial class App : Application
    {
        public IPenaltyApiService penaltyApiService = new PenaltyApiService();
        public IProvinceApiService provinceApiService = new ProvinceApiService();
        public App()
        {
            InitializeComponent();
            //Nueva pantalla de inicio: LogIn
            LogIn LogInView = new LogIn();
            NavigationPage.SetHasNavigationBar(LogInView, false);
            MainPage = new NavigationPage(LogInView);

        }

        protected override async void OnStart()
        {
            Config.Leyes = await GetLeyes();
            Config.Provincias = await GetProvincias();

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private async Task<ObservableCollection<Ley>> GetLeyes()
        {
            return await penaltyApiService.GetPenailtyTypesAsync();
        }
        private async Task<ObservableCollection<Provincia>> GetProvincias()
        {
            return await provinceApiService.GetProvincesAsync();
        }
    }
}
