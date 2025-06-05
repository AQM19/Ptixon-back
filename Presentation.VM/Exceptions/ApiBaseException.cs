using System.Net;

namespace Presentation.VMs.Helpers
{
    public class ApiBaseException : Exception
    {
        public DateTime Timestamp { get; }
        public ExceptionCodeEnum ExceptionCode { get; }
        public HttpStatusCode StatusCode { get; }

        public ApiBaseException(string message, ExceptionCodeEnum exceptionCode = ExceptionCodeEnum.Unknown, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
        {
            Timestamp = DateTime.UtcNow;
            ExceptionCode = exceptionCode;
            StatusCode = statusCode;
        }

        public ApiBaseException(string message, Exception innerException, ExceptionCodeEnum exceptionCode = ExceptionCodeEnum.Unknown, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message, innerException)
        {
            Timestamp = DateTime.UtcNow;
            ExceptionCode = exceptionCode;
            StatusCode = statusCode;
        }
    }
}
