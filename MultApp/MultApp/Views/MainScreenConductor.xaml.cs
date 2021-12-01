using MultApp.Models;
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
    public partial class MainScreenConductor : ContentPage
    {
        public MainScreenConductor()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}