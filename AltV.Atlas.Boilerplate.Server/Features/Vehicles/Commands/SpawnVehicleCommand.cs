using AltV.Atlas.Boilerplate.Server.Features.Commands.Extensions;
using AltV.Atlas.Boilerplate.Server.Features.Vehicles.Overrides;
using AltV.Atlas.Chat;
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

public class SpawnVehicleCommand( IAtlasVehicleFactory vehicleFactory, ILogger<SpawnVehicleCommand> logger ) : IExtendedCommand
{
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
            player.SendChatMessage( $"[Usage] { HelpText }" );
            return;
        }

        var vehicle = await vehicleFactory.CreateVehicleAsync<AtlasTuningVehicle>( model, player.Position, player.Rotation );
        player.SetIntoVehicle( vehicle, 1 );
    }

}