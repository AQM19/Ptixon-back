namespace Presentation.VMs.Helpers
{
    public class AppRateLimitingConfig
    {
        public required int PermitLimit { get; set; }
        public required int WindowMinutes { get; set; }
        public required int SegmentsPerWindow { get; set; }
        public required string QueueProcessingOrder { get; set; }
        public required int QueueLimit { get; set; }
    }
}
