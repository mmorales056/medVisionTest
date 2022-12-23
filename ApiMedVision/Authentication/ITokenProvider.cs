using Microsoft.IdentityModel.Tokens;
using Modelos;

namespace ApiMedVision.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(Usuario persona, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
    }
}
