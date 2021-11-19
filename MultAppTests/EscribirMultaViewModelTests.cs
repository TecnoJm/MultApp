using MultApp;
using MultApp.Models;
using MultApp.Services;
using MultApp.ViewModels;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MultAppTests
{
    public class EscribirMultaViewModelTests
    {
        EscribirMultaViewModel _vm;
        IPersonApiService PersonApiService = new PersonApiService();
        Persona Persona;

        [SetUp]
        public async Task Setup()
        {
            Persona = await PersonApiService.GetPersonByIdAsync(5);

            _vm = new EscribirMultaViewModel(new AlertService(), new NavigationService(), new PenaltyApiService(), Persona);
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
            ley.Monto = 1000.0000;

            _vm.LeyInfringida = ley;

            Assert.IsNotNull(_vm.LeyInfringida, "LeyInfringida is null after being initialized with a valid object");

        }

        [Test]
        public async Task EscribirMulta_Penalty_Created_Succesfully()
        {
            Multa multa = new Multa();
            multa.PersonId = Persona.Id;
            multa.PenaltyTypeId = 1;
            multa.ProvinceId = 1;
            multa.Address = "direccion test";
            multa.Description = "descripcion test";

            bool success = await _vm.PenaltyApiService.CreatePenaltyAsync(multa);


            Assert.IsTrue(success, "Penalty could not be created");

        }
    }
}
