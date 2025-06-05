namespace Presentation.VMs.Auth
{
    public class UserVM
    {
        public Guid Id { get; set; }

        public string? Role { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public bool IsAnonymous { get; set; }
    }
}
