
# API Error Handler
Error handling is a cumbersome task and often neglected. WHich leads to fragmentation and inconsistent responses. This aims to handle the problem. It provides an error framework which can just be plugged in with a few lines of code and you are set to go.

## Get Started
In order to use this error framework, you need to perform basic minimal number of steps.

### Install NuGet package
The framework for API comes bundled in a NuGet package. Download NuGetPackage

    Basket.Api.Framework

### Register Inbuilt Middleware
The framework has a middleware inbuilt to handle all errors and you do no need to create one. Just register the middleware in the Configure method inside your Startup.cs file

    app.UseMiddleware<BasketMiddleware>(apiErrorSettings);

The value of **apiErrorSettings**  define the settings for the error handling. It is optional.

### Use Inbuilt Error Response Methods
Now you are set up. The middleware will automatically cath all errors and return the reponse in a consistent manner. Any exceptions thrown will be automatically caught. In case you need to return a response manually, you can use some built in methods from your controller with messages and details.

    return ApiResponse.BadRequest("Bad request error");
    return ApiResponse.Conflict("Conflict error");

