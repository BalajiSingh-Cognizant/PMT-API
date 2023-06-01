using Authentication.API.Models;
using JwtExtensions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.API
{
    public class JwtTokenService
    {
        private readonly List<User> _users = new List<User>()
        {
            new User()
            {
                Username = "399584",
                Password = "mAn@ger",
                Role = "Manager"
            },
            new User()
            {
                Username = "466321",
                Password = "home21",
                Role = "Member"
            },
            new User()
            {
                Username = "manager",
                Password = "manager",
                Role = "Manager"
            },
            new User()
            {
                Username = "user",
                Password = "user",
                Role = "Member"
            }
        };

        public AuthenticationToken? GenerateAuthToken(LoginModel loginModel)
        {
            var user = _users.FirstOrDefault(u => u.Username == loginModel.Username && u.Password == loginModel.Password);

            if (user is null)
            {
                return null;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtAuthExtension.SecurityKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(5);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim("Role", user.Role),
            };

            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                expires: expirationTimeStamp,
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new AuthenticationToken(tokenString, (int)expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds);
        }
    }
}
