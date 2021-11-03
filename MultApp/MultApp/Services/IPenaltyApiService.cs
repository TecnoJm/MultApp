using MultApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public interface IPenaltyApiService
    {
        Task<ObservableCollection<Ley>> GetPenailtyTypesAsync();

        Task<bool> CreatePenaltyAsync(Multa multa);
    }
}
