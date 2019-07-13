using Basket.Api.Framework;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace Basket.Api.IntegrationTests
{
    public abstract class ApiTestBase
    {
        protected WebApplicationFactory<Basket.Api.Startup> _ApiFactory = null;
        protected HttpClient _ApiClient = null;

        protected abstract string _ControllerRoute { get; }

        protected string _BasePath
        {
            get
            {
                return $"api/{_ControllerRoute}";
            }
        }

        public void CreateClient(
            IApiErrorSettings apiErrorSettings = null)
        {
            apiErrorSettings = apiErrorSettings ?? new ApiErrorSettings();

            _ApiFactory = new WebApplicationFactory<Startup>();

            _ApiClient = _ApiFactory.WithWebHostBuilder(
                builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.Add(new ServiceDescriptor(typeof(IApiErrorSettings), apiErrorSettings));
                    });
                })
                .CreateClient();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _ApiClient.Dispose();
            _ApiFactory.Dispose();
        }
    }
}
