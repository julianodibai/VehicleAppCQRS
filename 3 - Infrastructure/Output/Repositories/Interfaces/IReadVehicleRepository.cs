using Output.DTOs;

namespace Input.Repositories.Interfaces
{
    public interface IReadVehicleRepository
    {
        IEnumerable<VehicleDTO> GetVehicles();
        VehicleDTO FindById(int id);
        IEnumerable<VehicleDTO> FindByCategoryId(int categoryId);
    }
}
