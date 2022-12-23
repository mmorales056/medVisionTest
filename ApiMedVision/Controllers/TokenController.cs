    using ApiMedVision.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using UnidadDeTrabajo;

namespace ApiMedVision.Controllers
{
    [ApiController]
    [Route("api/token")]
    public class TokenController : Controller
    {
        private ITokenProvider _tokenProvider;
        private IUnidadDeTrabajo _unidadDeTrabajo;
        public TokenController(ITokenProvider tokenProvider, IUnidadDeTrabajo unidadDeTrabajo)
        {
            _tokenProvider = tokenProvider;
            _unidadDeTrabajo = unidadDeTrabajo;        
        }

        [HttpPost]
        public JsonWebToken Post([FromBody] Usuario persona)
        {
            var user = _unidadDeTrabajo.Persona.ValidateUser(persona.Cedula, persona.Clave);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }
            var token = new JsonWebToken
            {
                Access_Token=_tokenProvider.CreateToken(persona,DateTime.UtcNow.AddHours(1)),
                Expires_in =  60                
            };

            return token;
        }
    }
}
