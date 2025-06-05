using System.Net;
using Presentation.VMs.Helpers;

namespace Presentation.VMs.Exceptions.Common
{
    public class NotFoundException : ApiBaseException
    {
        private const string DefaultMessage = "Resource not found";
        private const ExceptionCodeEnum DefaultExceptionCode = ExceptionCodeEnum.NotFound;
        private static readonly HttpStatusCode DefaultStatusCode = HttpStatusCode.NotFound;
        public NotFoundException(string message = DefaultMessage) : base(message, DefaultExceptionCode, DefaultStatusCode)
        {
        }
    }
}
