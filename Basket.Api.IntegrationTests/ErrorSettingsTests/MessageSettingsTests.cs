using Basket.Api.Framework;
using Basket.Api.IntegrationTests;
using Basket.Framework.Error;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Basket.Api.ErrorSettingsTests.IntegrationTests
{
    [TestClass]
    public class MessageSettingsTests : ApiTestBase
    {
        protected override string _ControllerRoute
        {
            get { return "error"; }
        }

        [TestMethod]
        public async Task IncludeExceptionDetail_DefaultSwitchedOff_DetailedExceptionInResponse()
        {
            //// Arrange
            CreateClient();

            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/random");

            //// Assert
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ErrorDetail>(responseContent);

            Assert.IsNull(responseData.Exception);
        }

        [TestMethod]
        public async Task IncludeExceptionDetail_SwitchedOn_NoExceptionInResponse()
        {
            //// Arrange
            var apiErrorSettings = new ApiErrorSettings
            {
                Message = new MessageSettings
                {
                    IncludeExceptionDetail = true
                }
            };

            CreateClient(apiErrorSettings);

            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/random");

            //// Assert
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ErrorDetail>(responseContent);

            Assert.IsNotNull(responseData.Exception);
            Assert.AreEqual("Random exception", responseData.Exception.Message);
        }
    }
}
