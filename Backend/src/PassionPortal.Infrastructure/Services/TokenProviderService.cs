using Domain.Authentication;
using PassionPortal.Infrastracture.Configurations;
using PassionPortal.Infrastracture.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace PassionPortal.Infrastracture.Services
{
    public class TokenProviderService(TokenConfiguration tokenConfiguration) : ITokenProviderService
    {
        public string CreateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            List<Claim>? claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Upn, user.UserName)
            };


            using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            RsaSecurityKey securityKey = new RsaSecurityKey(rsa);

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha512)
            {
                CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
            };
            rsa.ImportCspBlob(Convert.FromBase64String(tokenConfiguration.RsaPrivateKey));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(tokenConfiguration.ExpiresMinutes)),
                SigningCredentials = credentials
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
