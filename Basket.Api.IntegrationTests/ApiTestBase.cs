using System.Net.Http;
using Basket.Api.Framework;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                    builder.ConfigureTestServices(services =>
                    {
                        services.AddSingleton<IApiErrorSettings>(apiErrorSettings);
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
