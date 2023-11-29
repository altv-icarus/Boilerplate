using AltV.Atlas.IoC.Attributes;
using AltV.Atlas.Vehicles.Server.Entities;
using AltV.Atlas.Vehicles.Server.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Boilerplate.Server.Features.PlayerSpawns;

[Injectable(lifetime: ServiceLifetime.Transient)]
public class PlayerSpawner
{
    private readonly IAtlasVehicleFactory _vehicleFactory;

    public PlayerSpawner( IAtlasVehicleFactory vehicleFactory )
    {
        _vehicleFactory = vehicleFactory;
    }
    
    public async Task SpawnPlayerAsync( IPlayer player )
    {
        player.Spawn( new Position(-1509, -372, 42 ) );
        player.Position = new Position( -1509, -372, 42 );
        player.Model = ( uint ) PedModel.FreemodeMale01;
        player.Health = player.MaxHealth;
        player.Dimension = 0;
        player.GiveWeapon( WeaponModel.Musket, 5000, true );
        
        var vehicle = await _vehicleFactory.CreateVehicleAsync<AtlasTuningVehicle>( VehicleModel.Tenf2, new Position(-1509, -372, 42 ), player.Rotation );
        player.SetIntoVehicle( vehicle, 1 );
    }
}