using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultApp.Services
{
    public interface IAlertService
    {
        Task AlertAsync(string title, string description);
    }
}
