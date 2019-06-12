using Basket.Framework.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Basket.Api.Framework
{
    public class BasketMiddleware
    {
        private readonly RequestDelegate _NextRequest = null;
        private readonly ILogger _Logger = null;
        private readonly ApiErrorSettings _ApiErrorSettings = null;

        public BasketMiddleware(
            RequestDelegate nextRequest,
            ILogger<BasketMiddleware> logger,
            ApiErrorSettings apiErrorSettings)
        {
            _NextRequest = nextRequest;
            _Logger = logger;
            _ApiErrorSettings = apiErrorSettings ?? new ApiErrorSettings();
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _NextRequest(httpContext);
            }
            catch (Exception exception)
            {
                var errorMessage = string.IsNullOrWhiteSpace(exception.Message)
                    ? "An error has occurred"
                    : exception.Message;

                _Logger.LogError(exception, errorMessage);

                var exceptionInResponse = _ApiErrorSettings.Message.IncludeExceptionDetail
                    ? exception
                    : (Exception)null;

                var errorDetail = ErrorFactory.ToErrorDetail(
                    (int)HttpStatusCode.InternalServerError,
                    errorMessage,
                    exception: exceptionInResponse);

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = errorDetail.StatusCode;

                var serializerSettings = new JsonSerializerSettings();

                if (_ApiErrorSettings.Serialization.UseCamelCase)
                {
                    serializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                }

                var serializedErrorDetail = JsonConvert.SerializeObject(errorDetail, serializerSettings);
                await httpContext.Response.WriteAsync(serializedErrorDetail);
            }
        }
    }
}
