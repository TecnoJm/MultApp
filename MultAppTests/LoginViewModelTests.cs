using MultApp.Models;
using MultApp.Services;
using MultApp.ViewModels;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MultAppTests
{
    [TestFixture]
    public class LoginViewModelTests
    {
        LoginViewModel _vm;

        [SetUp]
        public void Setup()
        {
            _vm = new LoginViewModel(new AlertService(), new NavigationService(), new AppUserApiService(), new PersonApiService());
        }

        [Test]
        public void Login_UsernameIsSet()
        {
            _vm.Username = "Agente3";


            Assert.IsNotNull(_vm.Username, "Username is null after being initialized with a valid object");
        }

        [Test]
        public void Login_PasswordIsSet()
        {
            _vm.Password = "123";

            Assert.IsNotNull(_vm.Password, "Password is null after being initialized with a valid object");

        }

        [Test]
        public async Task Login_ApiGetsUser_With_Correct_Values()
        {
            _vm.Username = "demetrio";
            _vm.Password = "123";

            Usuario usuario = await _vm.AppUserApiService.UserLoginAsync(new Usuario() { Username = _vm.Username, Password = _vm.Password });
            
            Assert.IsNotNull(usuario, "Unable to get user from web api");
        }

        [Test]
        public async Task Login_Api_Does_Not_Get_User_With_Incorrect_Values()
        {
            _vm.Username = "asfed";
            _vm.Password = "126";

            Usuario usuario = await _vm.AppUserApiService.UserLoginAsync(new Usuario() { Username = _vm.Username, Password = _vm.Password });

            Assert.IsNull(usuario, "Got user even when there where incorrect values");
        }

        [Test]
        public async Task Login_ApiGetPerson_By_Correct_Person_Id()
        {
            Persona persona = await _vm.PersonApiService.GetPersonByIdAsync(5);
            
            Assert.IsNotNull(persona, "Unable to get person from web api");
        }

    }
}