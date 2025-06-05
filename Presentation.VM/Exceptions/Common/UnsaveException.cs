using System.Net;
using Presentation.VMs.Helpers;

namespace Presentation.VM.Exceptions.Common
{
    public class UnsaveException : ApiBaseException
    {
        private const string DefaultMessage = "Couldn't save in database";
        private const ExceptionCodeEnum DefaultExceptionCode = ExceptionCodeEnum.ErrorSavingDatabase;
        private static readonly HttpStatusCode DefaultStatusCode = HttpStatusCode.InternalServerError;

        public UnsaveException(string message = DefaultMessage) : base(message, DefaultExceptionCode, DefaultStatusCode)
        { }
    }
}
