
# API Error Handler
Error handling is a cumbersome task and often neglected. WHich leads to fragmentation and inconsistent responses. This aims to handle the problem. It provides an error framework which can just be plugged in with a few lines of code and you are set to go.

## Get Started
In order to use this error framework, you need to perform basic minimal number of steps.

### Install NuGet package
The framework for API comes bundled in a NuGet package. Download NuGetPackage

    Basket.Api.Framework

### Register Inbuilt Middleware
The framework has a middleware inbuilt to handle all errors and you do no need to create one. Just register the middleware in the Configure method inside your Startup.cs file

    public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiErrorSettings apiErrorSettings)
    {
        // Initialise settings if you need to change anything, if not provided
        // This is optional. You can also choose to pass null
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

The value of **apiErrorSettings**  define the settings for the error handling. It is optional.

### Use Inbuilt Error Response Methods
Now you are set up. The middleware will automatically cath all errors and return the reponse in a consistent manner. Any exceptions thrown will be automatically caught. In case you need to return a response manually, you can use some built in methods from your controller with messages and details.

    [Route("not-found")]
    public async Task<IActionResult> NotFound()
    {
        return ApiResponse.NotFound("Not found error");
    }

    [Route("bad-request")]
    public async Task<IActionResult> BadRequest()
    {
        return ApiResponse.BadRequest("Bad request error");
    }

There are other methods with other error codes supported. If you cannot find a supported one, you can request an addition or just use InternalServerError method.

