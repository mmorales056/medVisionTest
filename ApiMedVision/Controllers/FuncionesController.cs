using Microsoft.AspNetCore.Mvc;
using UnidadDeTrabajo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMedVision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionesController : ControllerBase
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public FuncionesController(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo= unidadDeTrabajo;

        }

        [HttpGet]
        [Route("getCitas/{cedula}")]
        public ActionResult GetCitasPersona(string cedula) {
            return Ok(_unidadDeTrabajo.Persona.CitasPersona(cedula));
        }

        [HttpGet]
        [Route("getFecha/{fecha}")]
        public ActionResult GetCitasFecha(string fecha)
        {
            return Ok(_unidadDeTrabajo.Persona.CitasFecha(fecha));
        }

        [HttpGet]
        [Route("cantidadMotivo")]
        public ActionResult GetCantidadMotivo()
        {
            return Ok(_unidadDeTrabajo.Persona.CantidadMotivo());
        }




    }
}
