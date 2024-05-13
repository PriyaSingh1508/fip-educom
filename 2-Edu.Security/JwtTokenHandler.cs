using Edu.BLL.User;
using Edu.Shared.Models;
using Edu.Shared.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Edu.Security
{
    public class JwtTokenHandler
    {
        public const string JWT_SECRET = "akjsbcjhvahsvclhgyuasgycasbchlgoalsgcb123hasjckvvascsajcbhjv";
        private const int JWT_EXPIRY_TIME = 60;
        private readonly UserBLL _userService;
        public JwtTokenHandler(UserBLL userService)
        {
            _userService = userService;
        }

        public async Task<AuthResponse?> GenerateJwtToken(AuthRequest AuthRequest)
        {
            if (string.IsNullOrWhiteSpace(AuthRequest.Email) || string.IsNullOrWhiteSpace(AuthRequest.Password))
            {
                return null;
            }
            UserDTO user = await _userService.GetUser(AuthRequest.Email,AuthRequest.Password);
            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JWT_SECRET);
            var TokenExpiryTime = DateTime.UtcNow.AddMinutes(JWT_EXPIRY_TIME);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Role)
                }),
                Expires = TokenExpiryTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new AuthResponse
            {
                Email =user.Email,
                ExpiryTime = (int)DateTime.UtcNow.AddMinutes(JWT_EXPIRY_TIME).Subtract(DateTime.Now).TotalSeconds,
                JwtToken = tokenString,
                Role=user.Role

            };


        }

    }
}