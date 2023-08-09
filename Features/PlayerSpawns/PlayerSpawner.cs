using AltV.Icarus.IoC.Attributes;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Icarus.Boilerplate.Features.PlayerSpawns;

[Injectable(lifetime: ServiceLifetime.Transient)]
public class PlayerSpawner
{
    public async Task SpawnPlayerAsync( IPlayer player )
    {
        player.Spawn( new Position(-1509, -372, 42 ) );
        player.Position = new Position( -1509, -372, 42 );
        player.Model = ( uint ) PedModel.FreemodeMale01;
        player.Health = player.MaxHealth;
        player.Dimension = 0;
        player.GiveWeapon( WeaponModel.Musket, 5000, true );
        var vehicle = await AltAsync.CreateVehicle( VehicleModel.Tenf2, new Position(-1509, -372, 42 ), player.Rotation );
        player.SetIntoVehicle( vehicle, 1 );
    }
}