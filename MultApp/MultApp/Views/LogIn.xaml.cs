using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MultApp.ViewModels;
using MultApp.Services;

namespace MultApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        public LogIn()
        {
            InitializeComponent();

            Username.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                LoginButton.Command.Execute(null);
            };
        }
    }
}