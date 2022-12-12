using _4___Domain.Entities;
using Dapper;
using Input.Queries;
using Input.Repositories.Interfaces;
using Shared.Factory;
using System.Data;

namespace Input.Repositories
{
    public class WriteVehicleRepository : IWriteVehicleRepository
    {
        private readonly IDbConnection _connection;
        public WriteVehicleRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }
        public void InsertVehicle(VehicleEntity vehicle)
        {
            var query = new VehicleQuery().InsertVehicleQuery(vehicle);

            try
            {
                using (_connection)
                {
                    _connection.Execute(query.Query, query.Parameters);
                }
            }
            catch
            {
                throw new Exception("Erro ao inserir veiculo");
            }

        }
    }
}
