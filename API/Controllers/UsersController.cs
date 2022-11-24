using API.DTOs.users;
using API.Interfaces.Users;
using API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers([FromQuery] UserParams userParams)
        {
            var userDto =await _userRepository.GetAllUsersAsync(userParams);

            return Ok(userDto);
        }
    
}
}