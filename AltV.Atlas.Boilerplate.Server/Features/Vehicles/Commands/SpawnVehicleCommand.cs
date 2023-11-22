using AltV.Atlas.Boilerplate.Server.Features.Commands.Extensions;
using AltV.Atlas.Boilerplate.Server.Features.Vehicles.Overrides;
using AltV.Atlas.Commands.Interfaces;
using AltV.Atlas.Shared.Extensions;
using AltV.Atlas.Vehicles.Entities;
using AltV.Atlas.Vehicles.Factories;
using AltV.Atlas.Vehicles.Interfaces;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using Microsoft.Extensions.Logging;

namespace AltV.Atlas.Boilerplate.Server.Features.Vehicles.Commands;

public class SpawnVehicleCommand : IExtendedCommand
{
    private readonly IAtlasVehicleFactory _vehicleFactory;
    private readonly ILogger<SpawnVehicleCommand> _logger;

    public SpawnVehicleCommand( IAtlasVehicleFactory vehicleFactory, ILogger<SpawnVehicleCommand> logger )
    {
        _vehicleFactory = vehicleFactory;
        _logger = logger;


        Task.Run( async ( ) =>
        {
            var veh = await _vehicleFactory.CreateVehicleAsync<ExtendedVehicle>( ( uint ) VehicleModel.Adder, new Position( 0, 0, 0 ), new Rotation( 0, 0, 0 ) );
            _logger.LogInformation( "Veh: {Type}", veh.GetType(  ) );
            
            _logger.LogInformation( "ID: {Id}, Plate: {Numberplate}", veh.Id, veh.NumberplateText );
            veh.NumberPlate = "Test";
            _logger.LogInformation( "2: ID: {Id}, Plate: {Numberplate}", veh.Id, veh.NumberplateText );
            
        } ).HandleException(_logger, "Failed to create vehicle" );
    }

    public string Name { get; set; } = "vehicle";
    public string[ ]? Aliases { get; set; } = new[ ] { "v", "sv" };
    public string Description { get; set; } = "Spawns the specified vehicle at your location";
    public uint RequiredLevel { get; set; } = 0;
    public string HelpText { get; set; } = "/vehicle [model name]";
    
    public async Task OnCommand( IPlayer player, string vehicleName )
    { 
        if( player.IsInVehicle )
        {
            player.Vehicle.Destroy( );
        }
        
        var model = VehicleList.GetVehicleModelByName( vehicleName );
        
        if( model == default )
        {
            player.Emit( "chat:message", $"[Usage] { HelpText }" );
            //TODO: Send chat message once chat module is added
            return;
        }

        var vehicle = await _vehicleFactory.CreateVehicleAsync<ExtendedVehicle>( model, player.Position, player.Rotation );
        _logger.LogInformation( "Vehicle type: {Type}", vehicle.GetType( ) );
        vehicle.NumberPlate = "extended";
        player.SetIntoVehicle( vehicle, 1 );
    }

}