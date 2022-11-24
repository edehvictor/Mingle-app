using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenServices: ITokenServices
    {
         private readonly UserManager<AppUser> _useManager;
         private readonly IConfiguration _config;

         private readonly SymmetricSecurityKey  _Key;

         public TokenServices(UserManager<AppUser> userManager, IConfiguration config)
         {
            _useManager =userManager;
            _config =config;
            _Key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(_config["Token:Key"]));
         }
            public async Task<string>GenerateAccessTokenAsync(AppUser user)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                };

                //Add user roles to claims
                var roles  =await _useManager.GetRolesAsync(user);
                claims.AddRange(roles.Select(r =>new Claim(ClaimTypes.Role, r)));

                //Sign security key
                var signingCredentials =new SigningCredentials(_Key, SecurityAlgorithms.HmacSha256);

                //Describe how the token will look like after generation
                var tokenDescriptor =new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires =DateTime.UtcNow.AddDays(7),
                    SigningCredentials =signingCredentials,
                    Issuer =_config["Token:Issuer"],
                    Audience =_config["Token:Audience"]
                };
                 //Create thr jwt access token
                var tokenHandler =new JwtSecurityTokenHandler();
                var token =tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }

         }
    }
