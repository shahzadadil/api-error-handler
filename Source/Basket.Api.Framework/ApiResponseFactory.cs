using Basket.Framework.Error;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace Basket.Api.Framework
{
    public static class ApiResponseFactory
    {
        public static ObjectResult ToObjectResult(
            string message,
            string description = null,
            IDictionary<string, object> metadata = null,
            Exception exception = null)
        {
            var errorDetail = ErrorFactory.ToErrorDetail(
                (int)HttpStatusCode.NotFound,
                message,
                description,
                metadata,
                exception);

            return new ObjectResult(errorDetail)
            {
                StatusCode = errorDetail.StatusCode
            };
        }
    }
}
