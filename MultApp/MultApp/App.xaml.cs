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
            MainPage = new NavigationPage(new LogIn());

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
