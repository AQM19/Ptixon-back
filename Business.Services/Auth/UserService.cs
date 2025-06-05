using AutoMapper;
using Business.DTOs.Auth;
using Business.Interfaces.Auth;
using Data.Access.Entities.Auth;
using Data.Access.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Business.Services.Auth
{
    public class UserService : BaseService, IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ICollection<UserDTO>> GetAllUsersAsync()
        {
            ICollection<User> users = await _unitOfWork.Users.GetAllAsync();
            ICollection<UserDTO> userDTOs = _mapper.Map<ICollection<UserDTO>>(users);

            return userDTOs;
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            User user = await _unitOfWork.Users.FindFirstByAsync(x => x.Email == email);
            if (user == null)
            {
                return null;
            }

            UserDTO userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public async Task<UserDTO> GetUserByIdAsync(Guid id)
        {
            User user = await _unitOfWork.Users.FindFirstByAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }

            UserDTO userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }
    }
}
