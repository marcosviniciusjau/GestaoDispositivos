using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Security;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Management.Smo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestaoDispositivos.Infra.Security
{
   internal class TokenGenerator : ITokenGenerator
    {
        private readonly uint _expirationMinutes;
        private readonly string _signingKey;
        public TokenGenerator(uint expirationMinutes, string signingKey)
        {
            _expirationMinutes = expirationMinutes;
            _signingKey = signingKey;
        }

        public string Generate(Cliente cliente)
        {
            var claims = new List<Claim>()
            {
                new(ClaimTypes.Sid, cliente.Id.ToString()),
                new(ClaimTypes.Name, cliente.Nome),
                new(ClaimTypes.Email, cliente.Email),
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationMinutes),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateAdmin(Admin admin)
        {
            var claims = new List<Claim>()
            {
                new(ClaimTypes.Sid, admin.Id.ToString()),
                new(ClaimTypes.Name, admin.Nome),
                new(ClaimTypes.Email, admin.Email),
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationMinutes),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private SymmetricSecurityKey SecurityKey()
        {
            var key = Encoding.UTF8.GetBytes(_signingKey);
            return new SymmetricSecurityKey(key);
        }
    }
}
