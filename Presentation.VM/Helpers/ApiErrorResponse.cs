namespace Presentation.VMs.Helpers
{
    public class ApiErrorResponse
    {
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; } = String.Empty;

        public static ApiErrorResponse FromException(ApiBaseException ex)
        {
            return new ApiErrorResponse
            {
                Timestamp = ex.Timestamp,
                StatusCode = (int)ex.ExceptionCode,
                ErrorMessage = ex.Message,
            };
        }
    }
}
