using Basket.Api.Framework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Api.IntegrationTests
{
    public class MockStartup : Startup
    {
        public MockStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            IApiErrorSettings apiErrorSettings)
        {
            base.Configure(app, env, apiErrorSettings);
        }


        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IApiErrorSettings, ApiErrorSettings>();
        }
    }
}
