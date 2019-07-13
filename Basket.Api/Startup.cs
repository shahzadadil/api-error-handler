using Basket.Api.Framework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Basket.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiErrorSettings apiErrorSettings = null)
        {
            // Initialise settings if you need to change anything, if not provided
            if (apiErrorSettings == null)
            {
                apiErrorSettings = new ApiErrorSettings
                {
                    Serialization = new SerializationSettings
                    {
                        UseCamelCase = true
                    },
                    Message = new Basket.Framework.Error.MessageSettings
                    {
                        IncludeExceptionDetail = true
                    },
                    Logging = new Basket.Framework.Logging.LoggingSettings
                    {
                        ShouldLogErrors = true
                    }
                };
            }

            app.UseMiddleware<BasketMiddleware>(apiErrorSettings);

            if (!env.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
