using _4___Domain.Enums;
using Input.Commands.Interfaces;

namespace Input.Commands.Vehicle
{
    public class VehicleCommand : ICommand
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public EVehicleType Type { get; set; }
    }
}
