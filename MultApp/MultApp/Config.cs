using MultApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
namespace MultApp
{
    public static class Config
    {
        public const string ApiKey = "AIzaSyA1s3jcQ0XKC-1HazAxpvBNwXEM3jmzYBo";


        public const string ApiUrl = "http://192.168.0.22:3000/api";
        //public const string ApiUrl = "https://multapp-api.herokuapp.com/api";

        public static ObservableCollection<Ley> Leyes { get; set; }
        public static ObservableCollection<Provincia> Provincias { get; set; }

        //Navigation Pages name
        public const string MainScreenAgente = "MainAgente";
        public const string MainScreenConductor = "MainCounductor";
        public const string VerEstadoMultaScreen = "EstadoMulta";
        public const string DetallesMultaScreen = "DetallesMulta";
        public const string EscribirMultaScreen = "EscribirMuta";
        public const string ListaMultaScreen = "ListaMulta";
        public const string LoginScreen = "Login";
        public const string RegisterScreen = "Register";
        public const string RegisterScreen2 = "Register22";
        public const string NavigationPage = "Navigation";
        public const string PagoScreen = "Pago";

        //Navigation Parameters name
        public const string PersonaParam = "Persona";
        public const string UsuarioParam = "Usuario";
        public const string MultaParam = "Multa";
    }
}
