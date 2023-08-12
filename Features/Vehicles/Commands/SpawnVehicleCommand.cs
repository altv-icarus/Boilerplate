using AltV.Icarus.Commands.Interfaces;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;

namespace AltV.Icarus.Boilerplate.Features.Vehicles.Commands;

public class SpawnVehicleCommand : IAsyncCommand
{
    public string Name { get; set; } = "vehicle";
    public string[ ] Aliases { get; set; } = new[ ] { "v", "sv" };
    public string Description { get; set; } = "/vehicle [model name]";
    public uint RequiredLevel { get; set; } = 0;
    
    public async Task OnCommandAsync( IPlayer player, string[ ] args )
    {
        if( player.IsInVehicle )
        {
            player.Vehicle.Destroy( );
        }

        var model = VehicleList.GetVehicleModelByName( args[ 0 ] );
        
        if( model == default )
        {
            player.Emit( "chat:message", $"[Usage] { Description }" );
            //TODO: Send chat message once chat module is added
            return;
        }

        var vehicle = await AltAsync.CreateVehicle( model, player.Position, player.Rotation );
        player.SetIntoVehicle( vehicle, 1 );
    }
}