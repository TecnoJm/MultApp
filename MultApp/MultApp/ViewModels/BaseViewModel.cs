using MultApp.Services;
using Prism.Navigation;
using Prism.Services;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public IAlertService AlertService { get; }
        public INavigationService NavigationService { get; }
        public bool IsBusy { get; set; }
        public bool IsApiBusy { get; set; }
        public ICommand BackCommand { get; }

        protected BaseViewModel(IAlertService alertService, INavigationService navigationService)
        {
            BackCommand = new Command(OnBack);
            AlertService = alertService;
            NavigationService = navigationService;
        }

        protected async Task RunIsBusyTaskAsync(Func<Task> awaitableTask)
        {
            if (IsBusy)
            {
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
        private async void OnBack()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.GoBackAsync();
            });
        }
    }
}
