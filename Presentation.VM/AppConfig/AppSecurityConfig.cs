namespace Presentation.VMs.Helpers
{
    public class AppSecurityConfig
    {
        public required string Token { get; set; }
        public required int HoursTokenExpiration { get; set; }
    }
}
