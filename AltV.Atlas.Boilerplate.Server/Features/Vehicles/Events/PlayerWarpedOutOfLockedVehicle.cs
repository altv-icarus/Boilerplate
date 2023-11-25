using AltV.Atlas.Chat;
using AltV.Atlas.IoC.Attributes;
using AltV.Atlas.Vehicles.AltV.Interfaces;
using AltV.Atlas.Vehicles.Events;
using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Boilerplate.Server.Features.Vehicles.Events;

[Injectable(InstantiateOnBoot = true)]
public class PlayerWarpedOutOfLockedVehicle
{
    public PlayerWarpedOutOfLockedVehicle( AtlasVehicleEvents atlasVehicleEvents )
    {
        atlasVehicleEvents.OnPlayerWarpedOutOfLockedVehicle += OnPlayerWarpedOutOfLockedVehicle;
    }

    private void OnPlayerWarpedOutOfLockedVehicle( IPlayer player, IAtlasVehicle vehicle, byte seat )
    {
        player.SendChatMessage( "This vehicle is locked, you can't enter it." );
    }
}