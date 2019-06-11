using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

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
            return ApiResponseFactory.ToObjectResult(
                HttpStatusCode.NotFound,
                message,
                description,
                metadata,
                exception);
        }

        public static IActionResult BadRequest(
            string message,
            string description = null,
            IDictionary<string, object> metadata = null,
            Exception exception = null)
        {
            return ApiResponseFactory.ToObjectResult(
                HttpStatusCode.BadRequest,
                message,
                description,
                metadata,
                exception);
        }

        public static IActionResult Forbidden(
            string message,
            string description = null,
            IDictionary<string, object> metadata = null,
            Exception exception = null)
        {
            return ApiResponseFactory.ToObjectResult(
                HttpStatusCode.Forbidden,
                message,
                description,
                metadata,
                exception);
        }

        public static IActionResult NoContent(
            string message,
            string description = null,
            IDictionary<string, object> metadata = null,
            Exception exception = null)
        {
            return ApiResponseFactory.ToObjectResult(
                HttpStatusCode.NoContent,
                message,
                description,
                metadata,
                exception);
        }

        public static IActionResult Unauthorized(
            string message,
            string description = null,
            IDictionary<string, object> metadata = null,
            Exception exception = null)
        {
            return ApiResponseFactory.ToObjectResult(
                HttpStatusCode.Unauthorized,
                message,
                description,
                metadata,
                exception);
        }

        public static IActionResult Conflict(
            string message,
            string description = null,
            IDictionary<string, object> metadata = null,
            Exception exception = null)
        {
            return ApiResponseFactory.ToObjectResult(
                HttpStatusCode.Conflict,
                message,
                description,
                metadata,
                exception);
        }

        public static IActionResult InternalServerError(
            string message,
            string description = null,
            IDictionary<string, object> metadata = null,
            Exception exception = null)
        {
            return ApiResponseFactory.ToObjectResult(
                HttpStatusCode.InternalServerError,
                message,
                description,
                metadata,
                exception);
        }
    }
}
