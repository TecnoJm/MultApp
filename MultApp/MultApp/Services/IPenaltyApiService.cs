using MultApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Threading.Tasks;

namespace MultApp.Services
{
    public interface IPenaltyApiService
    {
        Task<ObservableCollection<Ley>> GetPenailtyTypesAsync();
        Task<ObservableCollection<Multa>> GetPenailtiesByPersonIdAsync(int id);

        Task<bool> CreatePenaltyAsync(Multa multa);

    }
}
