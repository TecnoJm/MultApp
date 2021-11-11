using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Xamarin.Forms;

namespace MultApp.Services
{
    public interface INavigationService
    {
        Task NavigationAsync(Page page, bool hasNavigationBar);
        Task NavigationPopAsync();

    }
}
