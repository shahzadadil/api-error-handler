using Basket.Api.Framework;
using Basket.Framework.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace Basket.Api.IntegrationTests.ErrorSettingsTests
{
    [TestClass]
    public class LoggingSettingsTests : ApiTestBase
    {
        protected override string _ControllerRoute
        {
            get { return "error"; }
        }

        [TestMethod]
        public async Task ShouldLogErrors_DefaultSwitchedOff_LogsErrors()
        {
            //// Arrange
            CreateClient();

            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/random");

            //// Assert
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public async Task ShouldLogErrors_SwitchedOn_LogErrors()
        {
            //// Arrange
            var apiErrorSettings = new ApiErrorSettings
            {
                Logging = new LoggingSettings
                {
                    ShouldLogErrors = true
                }
            };

            CreateClient(apiErrorSettings);

            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/random");

            //// Assert
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}
