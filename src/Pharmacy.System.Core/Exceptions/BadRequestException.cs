using System.Net;

namespace Pharmacy.System.Core.Exceptions
{

    public sealed class BadRequestException : AppException
    {
        public BadRequestException(string message)
            : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
