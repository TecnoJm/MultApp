using MultApp.Models;
using MultApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MultApp.ViewModels
{
    public class ListaMultaViewModel : BaseViewModel
    {
        public ObservableCollection<Multa> Multas { get; set; }
        public ListaMultaViewModel(IAlertService alertService, INavigationService navigationService) : base(alertService, navigationService)
        {
            Multas = new ObservableCollection<Multa>()
            {
                new Multa(){LeyInfringida = "Ley infringida #1", FechaInfraccion = DateTime.Now},
                new Multa(){LeyInfringida = "Ley infringida #2", FechaInfraccion = DateTime.Now},
                new Multa(){LeyInfringida = "Ley infringida #3", FechaInfraccion = DateTime.Now},
                new Multa(){LeyInfringida = "Ley infringida #4", FechaInfraccion = DateTime.Now},
                new Multa(){LeyInfringida = "Ley infringida #5", FechaInfraccion = DateTime.Now}
            };
        }
    }
}
