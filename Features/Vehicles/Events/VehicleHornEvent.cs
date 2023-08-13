using AltV.Icarus.Boilerplate.Utils;
using AltV.Icarus.IoC.Attributes;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Icarus.Boilerplate.Features.Vehicles.Events;

[Injectable(InstantiateOnBoot = true)]
public class VehicleHornEvent
{
    public VehicleHornEvent( )
    {
        AltAsync.OnVehicleHorn += OnVehicleHorn;
    }

    private async Task<bool> OnVehicleHorn( IVehicle target, IPlayer reporter, bool state )
    {
        if( target.Driver is not IPlayer driver )
            return true;
        
        var vehicleModel = EnumUtils.RandomEnumValue<VehicleModel>( );

        var vehicle = await AltAsync.CreateVehicle( vehicleModel, target.Position, target.Rotation );
        target.Destroy( );
        driver.SetIntoVehicle( vehicle, 1 );
        
        return true;
    }
}