using API.DTOs.users;
using API.Utilities;

namespace API.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAllUsersAsync(UserParams userParams);
    }

}
