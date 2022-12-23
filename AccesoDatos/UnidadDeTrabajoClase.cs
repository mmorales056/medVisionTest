using Modelos;
using Repositorios;
using UnidadDeTrabajo;

namespace AccesoDatos
{
    public class UnidadDeTrabajoClase:IUnidadDeTrabajo
    {
        public UnidadDeTrabajoClase(string connecionString)
        {
            Persona = new PersonaRepositorio(connecionString);

        }

        public IPersonaRepositorio Persona { get; private set; }
    }
}
