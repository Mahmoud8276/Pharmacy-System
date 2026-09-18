using System;
using System.Net;

namespace Pharmacy.System.Core.Exceptions
{
    public abstract class AppException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public AppException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) 
            : base(message) 
        { 
            StatusCode = statusCode;
        }
    }
}
