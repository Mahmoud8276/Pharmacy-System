using System.Net;

namespace Pharmacy.System.Core.Exceptions
{
    public sealed class NotFoundException : AppException
    {
        public NotFoundException(string resourceName, object key) 
            : base($"{resourceName} with iD {key} not found!", HttpStatusCode.NotFound)
        {
        }
    }
}
