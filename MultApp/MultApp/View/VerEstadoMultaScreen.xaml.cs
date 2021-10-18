using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerEstadoMultaScreen : ContentPage
    {
        public VerEstadoMultaScreen(Services.AlertService alertService, Services.NavigationService navigationService)
        {
            InitializeComponent();
        }
    }
}