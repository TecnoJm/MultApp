using MultApp;
using MultApp.Models;
using MultApp.Services;
using MultApp.ViewModels;
using NUnit.Framework;
using System.Threading.Tasks;
using Prism;
using Prism.Navigation;

namespace MultAppTests
{
    public class EscribirMultaViewModelTests
    {
        EscribirMultaViewModel _vm;
        IPersonApiService PersonApiService = new PersonApiService();
        INavigationService NavigationService;
        Persona Persona;

        [SetUp]
        public async Task Setup()
        {
            Persona = await PersonApiService.GetPersonByIdAsync(5);

            _vm = new EscribirMultaViewModel(new AlertService(), NavigationService, new PenaltyApiService(), new ProvinceApiService());
        }

        [Test]
        public void EscribirMulta_ProvinciaIsSet()
        {
            Provincia provincia = new Provincia();
            provincia.Id = 1;
            provincia.Descripcion = "Santo Domingo";

            _vm.Provincia = provincia;

            Assert.IsNotNull(_vm.Provincia, "Provincia is null after being initialized with a valid object");
        }

        [Test]
        public void EscribirMulta_LeyInfringidaIsSet()
        {
            Ley ley = new Ley();
            ley.Id = 1;
            ley.Descripcion = "Conducir un vehículo con exceso de pasajero";
            ley.NumeroLey = "Ley 241 art. 104";
            ley.Precio = 1000.0000;

            _vm.Multa.Ley = ley;

            Assert.IsNotNull(_vm.Multa.Ley, "LeyInfringida is null after being initialized with a valid object");

        }

        [Test]
        public async Task EscribirMulta_Penalty_Created_Succesfully()
        {
            Multa multa = new Multa();
            multa.PersonId = Persona.Id;
            multa.Address = "direccion test";
            multa.Description = "descripcion test";

            bool success = await _vm.PenaltyApiService.CreatePenaltyAsync(multa);


            Assert.IsTrue(success, "Penalty could not be created");

        }
    }
}
