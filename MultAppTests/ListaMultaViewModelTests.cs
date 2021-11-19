using MultApp.Models;
using MultApp.Services;
using MultApp.ViewModels;
using NUnit.Framework;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MultAppTests
{
    public class ListaMultaVieModelTests
    {
        ListaMultaViewModel _vm;
        IPersonApiService PersonApiService = new PersonApiService();
        Persona Persona;

        [SetUp]
        public async Task Setup()
        {
            Persona = await PersonApiService.GetPersonByIdAsync(5);

            _vm = new ListaMultaViewModel(new AlertService(), new NavigationService(), new PenaltyApiService(), Persona);
        }


        [Test]
        public async Task ListaMulta_Get_Person_Penalties()
        {
            ObservableCollection<Multa> multas = await _vm.PenaltyApiService.GetPenailtiesByPersonIdAsync(Persona.Id);

            Assert.IsNotNull(multas, "Could not get penalties");

        }
    }
}
