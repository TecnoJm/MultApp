using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MultApp.View;

namespace MultApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Nueva pantalla de inicio: LogIn
            LogIn LogInView = new LogIn();
            NavigationPage.SetHasNavigationBar(LogInView, false);
            MainPage = new NavigationPage(LogInView);

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
