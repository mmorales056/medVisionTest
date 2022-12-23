using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Doctor { get; set; }
        public int IdPersona { get; set; }

    }
}
