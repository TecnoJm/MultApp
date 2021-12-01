using MultApp.Services;
using MultApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainScreenAgente : ContentPage
    {
        public MainScreenAgente()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}