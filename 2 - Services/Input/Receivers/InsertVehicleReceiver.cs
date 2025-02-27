﻿using _4___Domain.Entities;
using Input.Commands.Vehicle;
using Input.Receivers.Interfaces;
using Input.Repositories.Interfaces;

namespace Input.Receivers
{
    public class InsertVehicleReceiver : IReceiver<VehicleCommand, State>
    {
        private readonly IWriteVehicleRepository _repository;
        public InsertVehicleReceiver(IWriteVehicleRepository repository)
        {
            _repository = repository;
        }
        public State Action(VehicleCommand command)
        {
            var vehicle = new VehicleEntity(command.Name, command.Color
            , command.ModelYear, command.CategoryId, command.Price, command.Type);


            if (!vehicle.IsValid())
                return new State(400, "Falha ao inserir verifique os campos", vehicle.Notifications);

            try
            {
                _repository.InsertVehicle(vehicle);
                return new State(200, "Veiculo inserido com sucesso", vehicle);
            }
            catch (Exception ex)
            {
                return new State(500, ex.Message, null);
            }

        }
    }
}
