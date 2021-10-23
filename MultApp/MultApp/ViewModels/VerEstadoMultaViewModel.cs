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
        public string UserLicencia { get; set; }
        public string UserNombres { get; set; }
        public string UserApellidos { get; set; }
        public string UserNacimiento { get; set; }

        public class MyTableList
        {
            public string DocumentoLicencia { get; set; }
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public string Nacimiento { get; set; }
        }

        public ICommand VolverCommand { get; }
        public VerEstadoMultaViewModel(IAlertService alertService, INavigationService navigationService) : base(alertService, navigationService)
        {
            VolverCommand = new Command(OnVolver);
            //
            string serverdbname = "MultAppDB";
            string servername = "192.168.0.14";
            string serveruser = "Test";
            string serverpasword = "123456";

            string sqlconnectionstring = $"Data Source = {servername}; Initial Catalog = {serverdbname}; User Id={serveruser}; Password={serverpasword};";
            SqlConnection sqlconnection = new SqlConnection(sqlconnectionstring);

            //Abrir y cerrar la base de datos, siempre realizable mientas usemos la base de datos
            sqlconnection.Open();
            
            string queryString = "Select * from dbo.Person";
            SqlCommand sqlcommand = new SqlCommand(queryString, sqlconnection);
            SqlDataReader sqlreader = sqlcommand.ExecuteReader();
            while (sqlreader.Read())
            {

            }

            sqlconnection.Close();
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
