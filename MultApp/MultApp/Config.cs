using MultApp.Helpers;
using MultApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
namespace MultApp
{
    public static class Config
    {
        public const string ApiKey = Secrets.ApiKey;


        public const string ApiUrl = "https://multapp-api.herokuapp.com/api";

        public static ObservableCollection<Ley> Leyes { get; set; }
        public static ObservableCollection<Provincia> Provincias { get; set; }

    }
}
