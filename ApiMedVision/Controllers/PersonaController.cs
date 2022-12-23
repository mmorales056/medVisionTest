using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using UnidadDeTrabajo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMedVision.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PersonaController : ControllerBase
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public PersonaController(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;

        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unidadDeTrabajo.Persona.GetList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(_unidadDeTrabajo.Persona.Insert(persona));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Persona persona)
        {
            if(ModelState.IsValid && _unidadDeTrabajo.Persona.Update(persona))
            {
                return Ok(new {Mensaje="la persona Fue actualizada"});
            }
            return BadRequest();    
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Persona persona) {
            if(persona.id > 0)
            {
                return Ok(_unidadDeTrabajo.Persona.Delete(persona));
            }
            return BadRequest();
        }


    }
}
