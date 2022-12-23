using Microsoft.IdentityModel.Tokens;
using Modelos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ApiMedVision.Authentication
{
    public class JwtProvider : ITokenProvider
    {
        private RsaSecurityKey _key;
        private string _algoritm;
        private string _issuer;
        private string _audience;

        public JwtProvider(string issuer, string audience, string keyName)
        {
            var parameters = new CspParameters() { KeyContainerName = keyName };
            var provider = new RSACryptoServiceProvider(2048, parameters);
            _key = new RsaSecurityKey(provider);
            _algoritm = SecurityAlgorithms.RsaSha256Signature;
            _issuer = audience;
        }
        public string CreateToken(Usuario persona, DateTime expiry)
        {
            JwtSecurityTokenHandler tokenHandler= new JwtSecurityTokenHandler();
            var identity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name,$"{persona.Cedula}")
            }, "Custom");

            SecurityToken token = tokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
            {
                Audience = _audience,
                Issuer = _issuer,
                SigningCredentials = new SigningCredentials(_key, _algoritm),
                Expires = expiry.ToUniversalTime(),
                Subject = identity
            });

            return  tokenHandler.WriteToken(token);
        }

     
        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                IssuerSigningKey = _key,
                ValidAudience = _audience,
                ValidIssuer = _issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0),
            };
        }
    }
}
