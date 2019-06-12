using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace Basket.Api.IntegrationTests
{
    public abstract class ApiTestBase
    {
        private WebApplicationFactory<Basket.Api.Startup> _ApiFactory = null;
        protected HttpClient _ApiClient = null;

        protected abstract string _ControllerRoute { get; }

        protected string _BasePath
        {
            get
            {
                return $"api/{_ControllerRoute}";
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _ApiFactory = new WebApplicationFactory<Startup>();
            _ApiClient = _ApiFactory.CreateClient();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _ApiClient.Dispose();
            _ApiFactory.Dispose();
        }
    }
}
