using API.Entities;

namespace API.Interfaces.Services
{
    public interface ITokenServices
    {
        Task<string> GenerateAccessTokenAsync(AppUser user);
        
    }
}
