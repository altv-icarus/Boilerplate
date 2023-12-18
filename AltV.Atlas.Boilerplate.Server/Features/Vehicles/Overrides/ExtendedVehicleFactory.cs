using AltV.Atlas.Vehicles.Server.Factories;
using AltV.Net;
using AltV.Net.Data;
using Microsoft.Extensions.Logging;
namespace AltV.Atlas.Boilerplate.Server.Features.Vehicles.Overrides;

public class ExtendedVehicleFactory( ILogger<AtlasVehicleFactory> logger, IServiceProvider serviceProvider ) : AtlasVehicleFactory( logger, serviceProvider )
{
    public async Task<ExtendedVehicle> CreateVehicleAsync( string model, Position position, Rotation rotation )
    {
        var vehicle = await CreateVehicleAsync<ExtendedVehicle>( Alt.Hash( model ), position, rotation );
        vehicle.NumberPlate = "We extended it";

        return vehicle;
    }
}