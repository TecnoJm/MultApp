﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MultApp.View;
using MultApp.Services;

namespace MultApp.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public Action DisplayInvalidLoginPrompt;
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel(IAlertService alertService, INavigationService navigationService) : base(alertService, navigationService)
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public async void OnSubmit()
        {
            //Codigo de pruebas de ingreso
            if (Email == "Usuario" && Password == "123")
            {
                await NavigationService.NavigationAsync(new MainScreen(), false);
            }
            else
            {
                await AlertService.AlertAsync("Error", "Usuario o Contraseña Invalidos");
            }
        }
    }
}
