using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Data.SqlClient;
using Xamarin.Forms;
using MultApp.Services;

namespace MultApp.ViewModels
{
    public class EscribirMultaViewModel : BaseViewModel
    {
        public ObservableCollection<string> LeyInfringida { get; set; }
        public int InfraccionSeleccionada { get; set; }

        public ICommand RegistrarInfraccionCommand { get; }
        public ICommand VolverCommand { get; }
        public string UserLicencia { get; set; }
        public int NumeroLey { get; set; }

        public EscribirMultaViewModel(IAlertService alertService, INavigationService navigationService) : base(alertService, navigationService)
        {
            RegistrarInfraccionCommand = new Command(OnRegistrarInfraccion);
            VolverCommand = new Command(OnVolver);

            LeyInfringida = new ObservableCollection<string>();
            for (int i = 0; i < 6; i++)
            {
                LeyInfringida.Add($"Item {i}");
            }
        }

        private async void OnRegistrarInfraccion()
        {
            try
            {        
                 string serverdbname = "MultAppDB";
                 string servername = "192.168.0.14";
                 string serveruser = "Test";
                 string serverpasword = "123456";

                 string sqlconnectionstring = $"Data Source = {servername}; Initial Catalog = {serverdbname}; User Id={serveruser}; Password={serverpasword};";
                 SqlConnection sqlconnection = new SqlConnection(sqlconnectionstring);

                 //Abrir y cerrar la base de datos, siempre realizable mientas usemos la base de datos
                 sqlconnection.Open();
                 sqlconnection.Close();

                 using (SqlConnection con = new SqlConnection(sqlconnectionstring))
                  {
                      con.Open();
                      //Prueba de Insert SQL Test de Registro de Infraccion
                      using (SqlCommand sqlcmd = new SqlCommand("SET IDENTITY_INSERT dbo.Penalty ON; Insert Into dbo.Penalty (Id, Seq, Code, PersonId, PenaltyTypeId, Description, AddressLine1, ProvinceId, PenaltyDate , Paid, CreatedDate) values((Select MAX(id) + 1 as num from dbo.Penalty), 7, 12, (Select Id from dbo.Person where DocumentNumber = @NumeroDocumento), @LeyInfringida, 'Se ha saltado un semaforo', 'Campos', 1, '2021-10-20 17:18:00.680', 1, '2021-10-20 17:18:00.680') ", con))
                      {
                          sqlcmd.Parameters.Add(new SqlParameter("NumeroDocumento", UserLicencia));
                          sqlcmd.Parameters.Add(new SqlParameter("LeyInfringida", InfraccionSeleccionada));
                          sqlcmd.ExecuteNonQuery();
                      }
                      con.Close();
                  }

                await AlertService.AlertAsync("!", "Infraccion Colocada");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private async void OnVolver()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                await NavigationService.NavigationPopAsync();

            });
        }
    }
}
