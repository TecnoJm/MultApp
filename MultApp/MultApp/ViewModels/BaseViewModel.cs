using MultApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MultApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public IAlertService AlertService { get; }
        public INavigationService NavigationService { get; }
        public bool IsBusy { get; set; }
        public bool IsApiBusy { get; set; }

        protected BaseViewModel(IAlertService alertService, INavigationService navigationService)
        {
            AlertService = alertService;
            NavigationService = navigationService;
        }

        protected async Task RunIsBusyTaskAsync(Func<Task> awaitableTask)
        {
            if (IsBusy)
            {
                // prevent accidental double-tap calls
                return;
            }
            IsBusy = true;
            try
            {
                await awaitableTask();
            }
            finally
            {
                IsBusy = false;
            }
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
