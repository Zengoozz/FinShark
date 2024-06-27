
#region Token
// Create interface for the service with Method (CreateToken) ☑
// Inherit the interface ☑
// Bind the Interface ☑
// Inject IConfig and SymmetricSecurityKey for the JWT SigningKey ☑
// Implement the CreateToken ☑
// Defining claims for the email, Username ☑
// Create signing credintials(the hashing) Hmac512 type ☑
// Create token desc and handler and wrap it with the claims, expiring date, the signing creds, issuer and audience ☑
// Create token using the handler ☑
// Return token as string ☑
// Edit signingKey for longer version ☑ 
// Create NewUserDto with fields (Username, email, token) ☑ 
// Inject the token service in Account Controller ☑
// return in success of register the newUserDto with the token creation ☑
#endregion

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Interfaces;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{

    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }
        public string CreateToken(AppUser appUser)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, appUser.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, appUser.UserName),

            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}