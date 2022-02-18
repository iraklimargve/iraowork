using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project1.Models
{
    public class JWTManager : IJWTManager
    {

        private readonly IConfiguration iconfiguration;
        public JWTManager(IConfiguration configuration)
        {
            this.iconfiguration = configuration;
        }
        public Tokens Authenticate(Users users)
        {
            if (users.Name != "admin" || users.Password != "admin")
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token=tokenHandler.WriteToken(token) };
        }
    }
}
