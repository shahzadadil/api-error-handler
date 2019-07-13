# API Error Handler [![Build Status](https://shahzadadil.visualstudio.com/API%20Error%20Handler/_apis/build/status/Master%20Branch%20CI?branchName=master)](https://shahzadadil.visualstudio.com/API%20Error%20Handler/_build/latest?definitionId=7&branchName=master)

Error handling is a cumbersome task and often neglected. That leads to fragmentation and inconsistent responses. This aims to handle the problem. It provides an error framework which can just be plugged in with a few lines of code and you are set to go.

This repo targets to tackle the issue and provides with a framework to seamlessly handle the error and send responses back in a consistent structure that is fixed for all errors. Devs now don't have to worry about error handling or setting up a framework to do that or deciding on a structure. Everything is done to just get you started. It also provides a middleware just to allow you to register it and you are done :)




## What It Does

It allows you to just register a middleware to handle all exceptions and to send responses back in a consistent manner that is the same for all generated errors. No need to worry about anything related to how errors will be handled.�




## Quick Start

In order to use this error framework, you need to perform a basic minimum number of steps.




### Install NuGet package

The framework for API comes bundled in a NuGet package. Download NuGetPackage




� � Basket.Api.Framework




The package is hosted at [Basket.Api.Framework on NuGet](https://www.nuget.org/packages/Basket.Api.Framework/)




### Register Inbuilt Middleware

The framework has a middleware inbuilt to handle all errors and you do not need to create one. Just register the middleware in the Configure method inside your Startup.cs file




� � public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiErrorSettings apiErrorSettings)

� � {

� � � � // Initialise settings if you need to change anything, if not provided

� � � � // This is optional. You can also choose to pass null

� � � � if (apiErrorSettings == null)

� � � � {

� � � � � � apiErrorSettings = new ApiErrorSettings

� � � � � � {

� � � � � � � � Serialization = new SerializationSettings

� � � � � � � � {

� � � � � � � � � � UseCamelCase = true

� � � � � � � � },

� � � � � � � � Message = new Basket.Framework.Error.MessageSettings

� � � � � � � � {

� � � � � � � � � � IncludeExceptionDetail = true

� � � � � � � � }

� � � � � � };

� � � � }




� � � � app.UseMiddleware<BasketMiddleware>(apiErrorSettings);




� � � � if (!env.IsDevelopment())

� � � � {

� � � � � � // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

� � � � � � app.UseHsts();

� � � � }




� � � � app.UseHttpsRedirection();

� � � � app.UseMvc();

� � }




The value of **apiErrorSettings**� define the settings for error handling. It is optional.



### Use Inbuilt Error Response Methods

Now you are set up. The middleware will automatically catch all errors and return the response in a consistent manner. Any exceptions thrown will be automatically caught. In case you need to return a response manually, you can use some built-in methods from your controller with messages and details.




� � [Route("not-found")]

� � public async Task<IActionResult> NotFound()

� � {

� � � � return ApiResponse.NotFound("Not found error");

� � }




� � [Route("bad-request")]

� � public async Task<IActionResult> BadRequest()

� � {

� � � � return ApiResponse.BadRequest("Bad request error");

� � }


    
    [Route("internal-server-error")]
    public async Task<IActionResult> InteernalServerError()
    {
        return ApiResponse.InternalServerError("Internal Server error");
    }


There are other methods with other error codes supported. If you cannot find a supported one, you can request an addition or just use InternalServerError method.










## Response Schema




The response data for the errors are returned in the format below




|Parameter| Type |

|--|--|

| message | string |

| description | string |

| exception | object|

| statusCode | 	number|

| metadata | key-value pair of string and object




In case you need the response in Pascal casing, you can change that from Error Settings




## More Details

More details can be viewed on [Wiki](https://github.com/shahzadadil/api-error-handler/wiki)




## Release Notes

Below is the summary of the changes being done in each release. The list is not exhaustive, just an indication.




### 1.0.4

- Enabled settings to switch logging on/off (was on by default)

- Fix minor issues

- Improved code coverage

- Updated package tags and description