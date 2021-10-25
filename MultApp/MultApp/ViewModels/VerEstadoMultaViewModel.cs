using MultApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultApp.ViewModels
{
    public class VerEstadoMultaViewModel : BaseViewModel
    {
        public string UserBuscarLicencia { get; set; }
        public string UserLicencia { get; set; }
        public string UserNombres { get; set; }
        public string UserApellidos { get; set; }

        public ICommand VolverCommand { get; }
        public ICommand BuscarEstado { get; }
        public VerEstadoMultaViewModel(IAlertService alertService, INavigationService navigationService) : base(alertService, navigationService)
        {
            VolverCommand = new Command(OnVolver);
            BuscarEstado = new Command(OnBuscarEstado);
        }

        private async void OnBuscarEstado()
        {
            try
            {
                string serverdbname = "MultAppDB";
                string servername = "192.168.0.14";
                string serveruser = "Test";
                string serverpasword = "123456";

                string sqlconnectionstring = $"Data Source = {servername}; Initial Catalog = {serverdbname}; User Id={serveruser}; Password={serverpasword};";
                SqlConnection sqlconnection = new SqlConnection(sqlconnectionstring);

                //Consulta de Test para poder ver el estado de un Usuario
                sqlconnection.Open();

                string queryString = "Select * from dbo.Person where DocumentNumber = " + UserBuscarLicencia;
                SqlCommand sqlcommand = new SqlCommand(queryString, sqlconnection);
                SqlDataReader sqlreader = sqlcommand.ExecuteReader();

                while (sqlreader.Read())
                {
                    UserNombres = sqlreader["FirstName"].ToString();
                    UserApellidos = sqlreader["LastName"].ToString();
                    UserLicencia = sqlreader["DocumentNumber"].ToString();
                }

                sqlconnection.Close();
            }
            catch(Exception ex)
            {
                await AlertService.AlertAsync("Aviso", "Información incorrecta");
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
