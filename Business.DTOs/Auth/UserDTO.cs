namespace Business.DTOs.Auth
{
    public class UserDTO
    {

        public Guid Id { get; set; }

        public string? Role { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public bool IsAnonymous { get; set; }
    }
}
