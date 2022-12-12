using Input.Commands.Vehicle;
using Input.Receivers;
using Input.Repositories;
using Input.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Output.Repositories;
using Shared.Factory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<SqlFactory>();
builder.Services.AddTransient<IWriteVehicleRepository, WriteVehicleRepository>();
builder.Services.AddTransient<IReadVehicleRepository, ReadVehicleRepository>();
builder.Services.AddTransient<InsertVehicleReceiver>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIVehiclesAppCQRS v1");
});

app.MapGet("/vehicle/GetAll/", ([FromServices] IReadVehicleRepository repository) =>
{
    return repository.GetVehicles();
});

app.MapGet("/vehicle/GetById/", ([FromQuery] int id, [FromServices] IReadVehicleRepository repository) =>
{
    return repository.FindById(id);
});

app.MapGet("/vehicle/GetByCategoryId/", ([FromQuery] int categoryId, [FromServices] IReadVehicleRepository repository) =>
{
    return repository.FindByCategoryId(categoryId);
});

app.MapPost("/vehicle/PostVehicle/", ([FromServices] InsertVehicleReceiver receiver, [FromBody] VehicleCommand command) => {
    return receiver.Action(command);
});

app.Run();