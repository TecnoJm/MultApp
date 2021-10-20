using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MultApp.Services
{
    public class NavigationService : INavigationService
    {
        public Task NavigationAsync(Page page, bool hasNavigationBar)
        {
            if (!hasNavigationBar)
            {
                NavigationPage.SetHasNavigationBar(page, false);
            }
            return App.Current.MainPage.Navigation.PushAsync(page);
        }

        public Task NavigationPopAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }

    }
}
