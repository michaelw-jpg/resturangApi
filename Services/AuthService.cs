using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using resturangApi.Models;
using resturangApi.Repositories.Interface;
using resturangApi.Services.Iservices;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace resturangApi.Services
{
    public class AuthService(IUserRepository repo, IPasswordHasher hasher, IConfiguration configuration, IHttpContextAccessor _httpContextAccessor) : IAuthService
    {
        private readonly IUserRepository _repo = repo;
        private readonly IPasswordHasher _hasher = hasher;

        public async Task<string> Login(string name, string password)
        {
            var user = await _repo.GetUserByName(name);
            if (user == null)
            {
                return null;
            }
            bool isPasswordValid = _hasher.Verify(password, user.PasswordHash);
            if (!isPasswordValid)
            {
                return null;
            }
            var jwtToken = generateJwtToken(user);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Path = "/",
                Expires = DateTime.UtcNow.AddDays(1)
            };
            var httpContext = _httpContextAccessor.HttpContext;

            httpContext?.Response.Cookies.Append("jwtToken", jwtToken, cookieOptions);

            return "Login successful";
        }
        
        private string generateJwtToken(User user)
        {
            // Implement JWT token generation logic here
            //embedded information in the token about the user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));


            // sign in credentials
            // HmacSha512 says that we need a token that has a length of 60 characters 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                // who is the token for
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

    }
}
