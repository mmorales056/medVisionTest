using Modelos;
using Modelos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public interface IPersonaRepositorio:IRepositorio<Persona>
    {
        Persona ValidateUser(string cedula, string clave);
        IEnumerable<citasPersona> CitasPersona(string cedula);
        IEnumerable<CitasFecha>  CitasFecha(string fecha);
        IEnumerable<CantidadMotivo> CantidadMotivo();
    }
}
