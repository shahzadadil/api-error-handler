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
            HttpStatusCode httpStatusCode,
            string message,
            string description = null,
            IDictionary<string, object> metadata = null,
            Exception exception = null)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("Message is required");
            }

            var statusCode = (int)httpStatusCode;

            var errorDetail = ErrorFactory.ToErrorDetail(
                statusCode,
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
