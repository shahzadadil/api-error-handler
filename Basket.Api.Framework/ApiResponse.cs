using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Basket.Api.Framework
{
    public class ApiResponse
    {
        public static IActionResult NotFound(
            string message,
            string description = null,
            IDictionary<string, object> metadata = null,
            Exception exception = null)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("Message is required");
            }

            return ApiResponseFactory.ToObjectResult(
                message,
                description,
                metadata,
                exception);
        }
    }
}
