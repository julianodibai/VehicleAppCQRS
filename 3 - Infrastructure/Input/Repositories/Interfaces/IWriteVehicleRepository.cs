using _4___Domain.Entities;

namespace Input.Repositories.Interfaces
{
    public interface IWriteVehicleRepository
    {
        void InsertVehicle(VehicleEntity vehicle);
    }
}
