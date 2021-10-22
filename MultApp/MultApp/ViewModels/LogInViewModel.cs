using System;
using System.Data.SqlClient;
using System.Windows.Input;
using Xamarin.Forms;
using MultApp.Views;
using MultApp.Services;

namespace MultApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Action DisplayInvalidLoginPrompt;
        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand SubmitCommand { protected set; get; }

        public LoginViewModel(IAlertService alertService, INavigationService navigationService) : base(alertService, navigationService)
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public async void OnSubmit()
        {
            await RunIsBusyTaskAsync(async () =>
            {
                //Codigo de pruebas de ingreso
                if (Username != null && Password != null)
                {
                    try
                    {
                        //using (SqlCommand sqlcmd = new SqlCommand("Select * from dbo.AppUser where Username ='Agente1' and Password ='123456'", con))
                        //Conexion SQL Server Local (Esta conexion, solo sera de presentacion, se cambiara con una API en el futuro)

                        string serverdbname = "MultAppDB";
                        string servername = "192.168.0.14";
                        string serveruser = "Test";
                        string serverpasword = "123456";

                        string sqlconnectionstring = $"Data Source = {servername}; Initial Catalog = {serverdbname}; User Id={serveruser}; Password={serverpasword};";
                        SqlConnection sqlconnection = new SqlConnection(sqlconnectionstring);

                        //Abrir y cerrar la base de datos, siempre realizable mientas usemos la base de datos
                        sqlconnection.Open();
                        sqlconnection.Close();

                        //LogIn con la Base de Datos
                        using (SqlConnection con = new SqlConnection(sqlconnectionstring))
                        {
                            con.Open();
                            using (SqlCommand sqlcmd = new SqlCommand("Select * from dbo.AppUser where Username ='" + Username + "' and Password ='" + Password + "'", con))
                            { 
                                SqlDataReader datareader = sqlcmd.ExecuteReader();

                                if(datareader.Read())
                                {
                                    await AlertService.AlertAsync("!", "Bienvenido: " + Username);
                                    await NavigationService.NavigationAsync(new MainScreen(), false);
                                }
                                else
                                {
                                    await AlertService.AlertAsync("Error", "Usuario o Contraseña incorrecta");
                                }
                            }
                            con.Close();
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }
                else
                {
                    await AlertService.AlertAsync("Error", "Usuario o Contraseña Invalidos");
                }

            });

        }
    }
}
