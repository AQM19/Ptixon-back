using System.Net;
using Presentation.VMs.Helpers;

namespace Presentation.VM.Exceptions.Common
{
    public class UnauthorizedException : ApiBaseException
    {
        private const string DefaultMessage = "Unauthorized";
        private const ExceptionCodeEnum DefaultExceptionCode = ExceptionCodeEnum.Unauthorized;
        private static readonly HttpStatusCode DefaultStatusCode = HttpStatusCode.Unauthorized;

        public UnauthorizedException(string message = DefaultMessage) : base(message, DefaultExceptionCode, DefaultStatusCode)
        { }
    }
}
