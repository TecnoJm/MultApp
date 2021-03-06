using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public class AlertService : IAlertService
    {
        public Task AlertAsync(string title, string description)
        {
            return App.Current.MainPage.DisplayAlert(title, description, "Ok");
        }
    }
}
