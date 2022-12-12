using _4___Domain.Enums;
using _4___Domain.Notifications;
using _4___Domain.Specifications;
using _4___Domain.Validations;
using _4___Domain.Validations.Interfaces;

namespace _4___Domain.Entities
{
    public class VehicleEntity : BaseEntity, IValidate
    {
        public string Name { get; private set; }
        public string Color { get; set; }
        public int ModelYear { get; private set; }
        public int CategoryId { get; private set; }
        public double Price { get; private set; }
        public EVehicleType Type { get; private set; }
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        List<Notification> _notifications;


        public VehicleEntity(string name, string color, int modelYear, int categoryId, double price, EVehicleType type)
        {
            Name = name;
            Color = color;
            ModelYear = modelYear;
            CategoryId = categoryId;
            Price = price;
            Type = type;
            _notifications = new List<Notification>();
            PriceCalculate();
            IsValid();

        }


        // Validations
        public bool IsValid()
        {
            return
                new VehicleValidations(this).MinNameLength().MaxNameLength().IsValid();
        }

        // Notifications
        public void PullNotification(Notification notification)
        {
            this._notifications.Add(notification);
        }

        // Business Roles
        private void PriceCalculate()
        {
            if (new TaxExempleLogic().IsSatisfiedBy(this))
                return;

            this.Price = this.Price + (this.Price * 0.06);
        }
    }
}
