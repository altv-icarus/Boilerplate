using AltV.Atlas.Boilerplate.Features.Commands.Extensions;
using AltV.Atlas.Commands.Interfaces;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Boilerplate.Features.Vehicles.Commands;

public class SpawnVehicleCommand : IExtendedCommand
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
            player.Emit( "chat:message", $"[Usage] { HelpText }" );
            //TODO: Send chat message once chat module is added
            return;
        }
        
        var vehicle = await AltAsync.CreateVehicle( model, player.Position, player.Rotation );
        player.SetIntoVehicle( vehicle, 1 );
    }

}