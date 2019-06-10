using System;
using System.Collections.Generic;

namespace Basket.Framework.Error
{
    public static class ErrorFactory
    {
        public static ErrorDetail ToErrorDetail(
            int errorCode,
            string message,
            string description = null,
            IDictionary<string, object> metadata = null,
            Exception exception = null)
        {
            return new ErrorDetail(errorCode)
            {
                Message = message,
                Description = description,
                Metadata = metadata,
                Exception = exception
            };
        }
    }
}
