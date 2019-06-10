using System;
using System.Collections.Generic;

namespace Basket.Framework.Error
{
    public class ErrorDetail
    {
        public ErrorDetail(int statusCode)
        {
            StatusCode = statusCode;
            Metadata = new Dictionary<string, object>();
        }

        public string Message { get; set; }
        public string Description { get; set; }
        public Exception Exception { get; set; }
        public int StatusCode { get; private set; }
        public IDictionary<string, object> Metadata { get; set; }
    }
}
