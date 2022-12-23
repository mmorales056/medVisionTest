using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnidadDeTrabajo
{
    public  interface IUnidadDeTrabajo
    {
        IPersonaRepositorio Persona { get; }
    }
}
