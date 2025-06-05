using Business.DTOs.Auth;

namespace Business.Interfaces.Auth
{
    public interface IUserService
    {
        Task<ICollection<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(Guid id);
        Task<UserDTO> GetUserByEmailAsync(string email);
    }
}
