# API Response
Everything from handling error to sending responses is managed by the framework. The only things devs have to do is use the available options. They need to use the available methods that have been exposed and not the .Net Core provided methods. 

## Available Response Methods
Following repsonse methods are available now

    ApiResponse.NotFound
    ApiResponse.BadRequest
    ApiResponse.Forbidden
    ApiResponse.NoContent
    ApiResponse.Unauthorized
    ApiResponse.Conflict
    ApiResponse.InternalServerError

You can use any method that suits your need. If not, you can make use of the generic **ApiResponse.InternalServerError**

## Extending API Methods
In case you need to extend the available methods, you can submit a suggestion. Otherwise, you can also use a more raw form of a factory method to do that. 

    ApiResponseFactory.ToObjectResult
    
This allows you to pass your own status code and details.

