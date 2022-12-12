using Dapper;
using Input.Repositories.Interfaces;
using Output.DTOs;
using Output.Queries;
using Shared.Factory;
using System.Data;

namespace Output.Repositories
{
    public class ReadVehicleRepository : IReadVehicleRepository
    {
        private readonly IDbConnection _connection;
        public ReadVehicleRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }
        public IEnumerable<VehicleDTO> FindByCategoryId(int categoryId)
        {
            var query = new VehicleQueries().GetVehiclesByCategoryId(categoryId);
            try
            {
                using (_connection)
                {
                    return _connection.Query<VehicleDTO>(query.Query, query.Parameters) as List<VehicleDTO>;
                }
            }
            catch
            {
                throw new Exception("Falha ao recuperar veiculos");
            }
        }

        public VehicleDTO FindById(int id)
        {
            var query = new VehicleQueries().GetVehicleById(id);
            try
            {
                using (_connection)
                {
                    return _connection.QueryFirstOrDefault<VehicleDTO>(query.Query, query.Parameters) as VehicleDTO;
                }
            }
            catch
            {
                throw new Exception("Falha ao recuperar veiculo");
            }
        }

        public IEnumerable<VehicleDTO> GetVehicles()
        {
            var query = new VehicleQueries().GetAllVehicle();
            try
            {
                using (_connection)
                {
                    return _connection.Query<VehicleDTO>(query.Query) as List<VehicleDTO>;
                }
            }
            catch
            {
                throw new Exception("Falha ao recuperar veiculos");
            }
        }
    }
}
