using Basket.Framework.Error;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace Basket.Api.IntegrationTests
{
    [TestClass]
    public class ErrorControllerTests : ApiTestBase
    {
        protected override string _ControllerRoute
        {
            get { return "error"; }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            CreateClient();
        }

        [TestMethod]
        public async Task NotFound_TestResponse_ReturnsResponse()
        {
            //// Arrange
            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/not-found");

            //// Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ErrorDetail>(responseContent);

            Assert.AreEqual((int)HttpStatusCode.NotFound, responseData.StatusCode);
            Assert.AreEqual("Not found error", responseData.Message);
        }

        [TestMethod]
        public async Task BadRequest_TestResponse_ReturnsResponse()
        {
            //// Arrange
            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/bad-request");

            //// Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ErrorDetail>(responseContent);

            Assert.AreEqual((int)HttpStatusCode.BadRequest, responseData.StatusCode);
            Assert.AreEqual("Bad request error", responseData.Message);
        }

        [TestMethod]
        public async Task Forbidden_TestResponse_ReturnsResponse()
        {
            //// Arrange
            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/forbidden");

            //// Assert
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ErrorDetail>(responseContent);

            Assert.AreEqual((int)HttpStatusCode.Forbidden, responseData.StatusCode);
            Assert.AreEqual("Forbidden error", responseData.Message);
        }

        [TestMethod]
        public async Task NoContent_TestResponse_ReturnsResponse()
        {
            //// Arrange
            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/no-content");

            //// Assert
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ErrorDetail>(responseContent);

            Assert.AreEqual((int)HttpStatusCode.NoContent, responseData.StatusCode);
            Assert.AreEqual("No content error", responseData.Message);
        }

        [TestMethod]
        public async Task Unauthorized_TestResponse_ReturnsResponse()
        {
            //// Arrange
            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/unauthorized");

            //// Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ErrorDetail>(responseContent);

            Assert.AreEqual((int)HttpStatusCode.Unauthorized, responseData.StatusCode);
            Assert.AreEqual("Unauthorized error", responseData.Message);
        }

        [TestMethod]
        public async Task Conflict_TestResponse_ReturnsResponse()
        {
            //// Arrange
            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/conflict");

            //// Assert
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ErrorDetail>(responseContent);

            Assert.AreEqual((int)HttpStatusCode.Conflict, responseData.StatusCode);
            Assert.AreEqual("Conflict error", responseData.Message);
        }

        [TestMethod]
        public async Task InternalServerError_TestResponse_ReturnsResponse()
        {
            //// Arrange
            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/internal-server-error");

            //// Assert
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ErrorDetail>(responseContent);

            Assert.AreEqual((int)HttpStatusCode.InternalServerError, responseData.StatusCode);
            Assert.AreEqual("Internal Server error", responseData.Message);
        }

        [TestMethod]
        public async Task Random_TestResponse_ReturnsResponse()
        {
            //// Arrange
            //// Act
            var response = await _ApiClient.GetAsync($"{_BasePath}/random");

            //// Assert
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ErrorDetail>(responseContent);

            Assert.AreEqual((int)HttpStatusCode.InternalServerError, responseData.StatusCode);
            Assert.AreEqual("Random exception", responseData.Message);
        }

    }
}
