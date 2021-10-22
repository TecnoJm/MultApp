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
        public ICommand RegistrarInfraccionCommand { get; }
        public ICommand VolverCommand { get; }

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
                /*
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
                    using (SqlCommand sqlcmd = new SqlCommand("INSERT INTO values ()", con))
                    {
                        SqlDataReader datareader = sqlcmd.ExecuteReader();

                        if (datareader.Read())
                        {
                            await AlertService.AlertAsync("!", "Infraccion Colocada");
                        }
                        else
                        {
                            await AlertService.AlertAsync("Error", "Usuario o Contraseña incorrecta");
                        }
                    }
                    con.Close();
                }
                */
                await AlertService.AlertAsync("Error", "Infraccion Colocada");

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
