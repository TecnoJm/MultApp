using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MultApp.View;

namespace MultApp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EmailEntry"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PasswordEntry"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {
            //Codigo de pruebas de ingreso
            if (email == "Usuario" && password == "123")
            {
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new MainScreen());
            }
            else DisplayInvalidLoginPrompt();
        }
    }
}
