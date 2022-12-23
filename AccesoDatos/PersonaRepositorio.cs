using Dapper;
using Modelos;
using Modelos.DTO;
using Repositorios;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class PersonaRepositorio : Repositorio<Persona>, IPersonaRepositorio
    {
        public PersonaRepositorio(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<CitasFecha> CitasFecha(string fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Action", "citaFecha");
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<CitasFecha>(
                    "dbo.SPFunciones", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<citasPersona> CitasPersona(string cedula)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Cedula", cedula);
            parameters.Add("@Action", "citasPersona");
            

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<citasPersona>(
                    "dbo.SPFunciones", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<CantidadMotivo> CantidadMotivo()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "cantidadMotivo");
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<CantidadMotivo>(
                    "dbo.SPFunciones", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Persona ValidateUser(string cedula, string clave)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Cedula", cedula);
            parameters.Add("@Clave", clave);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Persona>(
                    "dbo.ValidarPersona", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

       
    }
}
