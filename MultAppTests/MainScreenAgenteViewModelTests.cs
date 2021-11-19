using MultApp.Models;
using MultApp.Services;
using MultApp.ViewModels;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MultAppTests
{
    public class MainScreenAgenteViewModelTests
    {
        MainScreenAgenteViewModel _vm;


        [SetUp]
        public void Setup()
        {
            _vm = new MainScreenAgenteViewModel(new AlertService(), new NavigationService(), new PersonApiService());
        }

        [Test]
        public void MainScreenAgente_DocumentoDeIdentidadIsSet()
        {
            _vm.DocumentoDeIdentidad = "123456789";

            Assert.IsNotNull(_vm.DocumentoDeIdentidad, "DocumentoDeIdentidad is null after being initialized with a valid object");

        }


        [Test]
        public async Task MainScreenAgente_ApiGetsPerson_With_Correct_Document()
        {
            _vm.DocumentoDeIdentidad = "123456789";

            Persona persona = await _vm.PersonApiService.GetPersonByDocumentAsync(_vm.DocumentoDeIdentidad);

            Assert.IsNotNull(persona, "Unable to get person from web api");

        }

        [Test]
        public async Task MainScreenAgente_Api_Does_Not_Get_Person_With_Incorrect_Document()
        {
            _vm.DocumentoDeIdentidad = "1234546189618";

            Persona persona = await _vm.PersonApiService.GetPersonByDocumentAsync(_vm.DocumentoDeIdentidad);

            Assert.IsNull(persona, "Got person even when there where incorrect values");

        }
    }
}
