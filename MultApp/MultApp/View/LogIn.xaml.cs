using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MultApp.ViewModel;

namespace MultApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        LogInView logInView;
        public LogIn()
        {
            logInView = new LogInView();
            InitializeComponent();
            BindingContext = logInView;
        }
    }
}