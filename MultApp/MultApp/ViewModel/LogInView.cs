using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MultApp.View;

namespace MultApp.ViewModel
{
    public class LogInView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LogInView()
        {

        }
        private string email;
        public string EmailEntry
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string PasswordEntry
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public Command LogInCommand
        {
            get
            {
                return new Command(Login);
            }
        }
        
        private void Login()
        {
            if (string.IsNullOrEmpty(EmailEntry) || string.IsNullOrEmpty(PasswordEntry))
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                if (EmailEntry == "jhonatan@gmail.com" && PasswordEntry == "abcde123")
                {
                    Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Bienvenido Jhonatan", "", "Ok");
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new MainScreen());
                }
                else
                    Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
            }
        }
    }
}
