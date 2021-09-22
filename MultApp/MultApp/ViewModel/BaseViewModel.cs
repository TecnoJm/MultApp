using MultApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MultApp.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public IAlertService AlertService { get; }
        public INavigationService NavigationService { get; }

        protected BaseViewModel(IAlertService alertService, INavigationService navigationService)
        {
            AlertService = alertService;
            NavigationService = navigationService;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
