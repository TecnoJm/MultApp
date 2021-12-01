using MultApp.Models;
using MultApp.Services;
using MultApp.ViewModels;
using NUnit.Framework;
using Prism.Navigation;
using System.Threading.Tasks;

namespace MultAppTests
{
    [TestFixture]
    public class LoginViewModelTests
    {
        LoginViewModel _vm;
        INavigationService NavigationService;

        [SetUp]
        public void Setup()
        {
            _vm = new LoginViewModel(new AlertService(), NavigationService, new AppUserApiService(), new PersonApiService());
        }

        [Test]
        public void Login_UsernameIsSet()
        {
            _vm.Usuario.Username = "Agente3";


            Assert.IsNotNull(_vm.Usuario.Username, "Username is null after being initialized with a valid object");
        }

        [Test]
        public void Login_PasswordIsSet()
        {
            _vm.Usuario.Password = "123";

            Assert.IsNotNull(_vm.Usuario.Password, "Password is null after being initialized with a valid object");

        }

        [Test]
        public async Task Login_ApiGetsUser_With_Correct_Values()
        {
            _vm.Usuario.Username = "demetrio";
            _vm.Usuario.Password = "123";

            Usuario usuario = await _vm.AppUserApiService.UserLoginAsync(new Usuario() { Username = _vm.Usuario.Username, Password = _vm.Usuario.Password });
            
            Assert.IsNotNull(usuario, "Unable to get user from web api");
        }

        [Test]
        public async Task Login_Api_Does_Not_Get_User_With_Incorrect_Values()
        {
            _vm.Usuario.Username = "asfed";
            _vm.Usuario.Password = "126";

            Usuario usuario = await _vm.AppUserApiService.UserLoginAsync(new Usuario() { Username = _vm.Usuario.Username, Password = _vm.Usuario.Password });

            Assert.IsNull(usuario.Persona, "Got user even when there where incorrect values");
        }

        [Test]
        public async Task Login_ApiGetPerson_By_Correct_Person_Id()
        {
            Persona persona = await _vm.PersonApiService.GetPersonByIdAsync(5);
            
            Assert.IsNotNull(persona, "Unable to get person from web api");
        }

    }
}