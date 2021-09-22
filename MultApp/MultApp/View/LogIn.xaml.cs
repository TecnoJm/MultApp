using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MultApp.ViewModel;
using MultApp.Services;

namespace MultApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        public LogIn()
        {
            InitializeComponent();
            var logInViewModel = new LoginViewModel(new AlertService(), new NavigationService());
            BindingContext = logInViewModel;

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                logInViewModel.SubmitCommand.Execute(null);
            };
        }
    }
}