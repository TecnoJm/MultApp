using MultApp.Models;
using MultApp.Services;
using MultApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit;

namespace MultApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaMultaScreen : ContentPage
    {
        public ListaMultaScreen(Persona persona)
        {
            InitializeComponent();
            BindingContext = new ListaMultaViewModel(new AlertService(), new NavigationService(), new PenaltyApiService(), persona);

        }

        private void ListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            // do stuff 

            ((ListView)sender).SelectedItem = null;
        }
    }
}