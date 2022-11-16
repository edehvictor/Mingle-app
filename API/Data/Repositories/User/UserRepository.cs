using API.DTOs.users;
using API.Extensions;
using API.Interfaces.Users;
using API.Utilities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly MingleDbContext _dbcontext;
        public UserRepository(MingleDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<UserDto>> GetAllUsersAsync(UserParams userParams)
        {
            var query = _dbcontext.Users.AsQueryable();

            query = query.Where(u => u.UserName != userParams.CurrentUsername);
            query = query.Where(u => u.Gender == userParams.Gender);

            var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
            var maxDob = DateTime.Today.AddYears(-userParams.MinAge);

            query = query.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);

            // switch (userParams.OrderBy)
            // {
            //     case "created":
            //         query = query.OrderByDescending(u => u.DateCreated);
            //         break;
            //     default:
            //         query = query.OrderByDescending(u => u.LastActive);
            //         break;
            // }

            query = userParams.Orderby switch
            {
                "created" => query.OrderByDescending(u => u.DateCreated),
                _=> query.OrderByDescending(u =>u.LastActive)
            };

            var userDots = await query
            .AsNoTracking().Select(a =>new UserDto{
                Fullname =a.Fullname,
                MainPhoto =a.Photos!.FirstOrDefault(p => p.IsMain)!.Url,
                Gender =a.Gender,
                Age =a.DateOfBirth.GetAge(),
                LastActive =a.LastActive,
                Created =a.DateCreated
            }).ToListAsync();

        return userDots;
        }
    }
}