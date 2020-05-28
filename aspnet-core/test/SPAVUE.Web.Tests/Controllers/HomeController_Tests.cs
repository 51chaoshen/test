using System.Threading.Tasks;
using SPAVUE.Models.TokenAuth;
using SPAVUE.Web.Controllers;
using Shouldly;
using Xunit;

namespace SPAVUE.Web.Tests.Controllers
{
    public class HomeController_Tests: SPAVUEWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}