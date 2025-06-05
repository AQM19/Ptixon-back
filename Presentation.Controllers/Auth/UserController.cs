using AutoMapper;
using Business.DTOs.Auth;
using Business.Interfaces.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.VMs.Auth;

namespace Presentation.Controllers.Auth
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger) : base(mapper, logger)
        {
            _userService = userService;
        }

        [HttpGet("/all")]
        [ProducesResponseType(typeof(IEnumerable<UserVM>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsers()
        {
            _logger.LogInformation("Fetching all users");

            ICollection<UserDTO> users = await _userService.GetAllUsersAsync();

            if (users == null || !users.Any())
            {
                _logger.LogWarning("No users found");
                return NotFound("No users found");
            }

            IEnumerable<UserVM> userVMs = _mapper.Map<IEnumerable<UserVM>>(users);

            return Ok(userVMs);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(UserVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            UserDTO user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                _logger.LogWarning($"User with ID {id} not found");
                return NotFound();
            }

            UserVM userVM = _mapper.Map<UserVM>(user);

            return Ok(userVM);
        }

        [HttpGet("email/{email}")]
        [ProducesResponseType(typeof(UserVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            UserDTO user = await _userService.GetUserByEmailAsync(email);

            if (user == null)
            {
                _logger.LogWarning($"User with email {email} not found");
                return NotFound();
            }

            UserVM userVM = _mapper.Map<UserVM>(user);

            return Ok(userVM);
        }
    }
}
