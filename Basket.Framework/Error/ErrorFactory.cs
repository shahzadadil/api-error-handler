using System;
using System.Collections.Generic;

namespace Basket.Framework.Error
{
    public static class ErrorFactory
    {
        public static ErrorDetail ToErrorDetail(
            int httpStatusCode,
            string message,
            string description = null,
            IDictionary<string, object> metadata = null,
            Exception exception = null)
        {
            return new ErrorDetail(httpStatusCode)
            {
                Message = message,
                Description = description,
                Metadata = metadata,
                Exception = exception
            };
        }
    }
}
