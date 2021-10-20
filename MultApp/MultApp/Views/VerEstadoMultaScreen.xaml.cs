using MultApp.Services;
using MultApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerEstadoMultaScreen : ContentPage
    {
        public VerEstadoMultaScreen()
        {
            InitializeComponent();
            BindingContext = new VerEstadoMultaViewModel(new AlertService(), new NavigationService());
        }
    }
}