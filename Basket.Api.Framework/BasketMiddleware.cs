using Basket.Framework.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Basket.Api.Framework
{
    public class BasketMiddleware
    {
        private readonly RequestDelegate _NextRequest = null;
        private readonly ILogger _Logger = null;

        public BasketMiddleware(
            RequestDelegate nextRequest,
            ILogger<BasketMiddleware> logger)
        {
            _NextRequest = nextRequest;
            _Logger = logger;
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

                var errorDetail = ErrorFactory.ToErrorDetail(
                    (int)HttpStatusCode.InternalServerError,
                    errorMessage);

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = errorDetail.StatusCode;
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorDetail));
            }
        }
    }
}
