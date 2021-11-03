using MultApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public interface IProvinceApiService
    {
        Task<ObservableCollection<Provincia>> GetProvincesAsync();
    }
}
