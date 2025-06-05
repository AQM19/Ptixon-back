namespace Presentation.VMs.Helpers
{
    public class AppEmailConfig
    {
        public required string SmtpServer { get; set; }
        public required int SmtpPort { get; set; }
        public required string SmtpUsername { get; set; }
        public required string SmtpPassword { get; set; }
        public required bool UseSSL { get; set; }
        public required string FromEmail { get; set; }
    }
}
