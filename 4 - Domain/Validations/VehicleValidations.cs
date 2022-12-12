using _4___Domain.Entities;
using _4___Domain.Notifications;
using _4___Domain.Validations.Interfaces;

namespace _4___Domain.Validations
{
    public class VehicleValidations : IValidate
    {
        private readonly VehicleEntity _vehicle;
        public VehicleValidations(VehicleEntity vehicle)
        {
            this._vehicle = vehicle;
        }

        public VehicleValidations MinNameLength()
        {
            if (_vehicle.Name.Length < 3)
                _vehicle.PullNotification(
                    new Notification(
                        "Name", "O nome deve conter um mínimo de 3 caracteres"));

            return this;
        }

        public VehicleValidations MaxNameLength()
        {
            if (_vehicle.Name.Length > 12)
                _vehicle.PullNotification(
                    new Notification(
                        "Name", "Quantidade máxima de caracteres ultrapassada"));

            return this;
        }

        public bool IsValid()
        {
            return (_vehicle.Notifications.Count == 0 ? true : false);
        }

    }
}
