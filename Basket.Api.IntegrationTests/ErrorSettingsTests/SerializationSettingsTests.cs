using Basket.Api.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Basket.Api.IntegrationTests.ErrorSettingsTests
{
    [TestClass]
    public class SerializationSettingsTests : ApiTestBase
    {
        protected override string _ControllerRoute
        {
            get { return "error"; }
        }

        [TestMethod]
        public async Task UseCamelCase_DefaultSwitchedOn_ResponseInCamelCase()
        {
            //// Arrange
            CreateClient();

            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/random");

            //// Assert
            var responseContent = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(responseContent.Contains("\"statusCode\":"));
            Assert.IsFalse(responseContent.Contains("\"StatusCode\":"));
        }

        [TestMethod]
        public async Task UseCamelCase_SwitchedOff_ResponseInTitleCase()
        {
            //// Arrange
            var apiErrorSettings = new ApiErrorSettings
            {
                Serialization = new SerializationSettings
                {
                    UseCamelCase = false
                }
            };

            CreateClient(apiErrorSettings);

            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/random");

            //// Assert
            var responseContent = await response.Content.ReadAsStringAsync();

            Assert.IsFalse(responseContent.Contains("\"statusCode\":"));
            Assert.IsTrue(responseContent.Contains("\"StatusCode\":"));
        }
    }
}
