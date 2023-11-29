using AltV.Atlas.IoC.Attributes;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Boilerplate.Server.Features.Vehicles.Events;

[Injectable(InstantiateOnBoot = true)]
public class VehicleHornEvent
{
    public VehicleHornEvent( )
    {
        AltAsync.OnVehicleHorn += OnVehicleHorn;
    }

    private async Task<bool> OnVehicleHorn( IVehicle target, IPlayer reporter, bool state )
    {
        // if( target.Driver is not IPlayer driver )
        //     return true;
        //
        // var vehicleModel = EnumUtils.RandomEnumValue<VehicleModel>( );
        //
        // var vehicle = await AltAsync.CreateVehicle( vehicleModel, target.Position, target.Rotation );
        // target.Destroy( );
        // driver.SetIntoVehicle( vehicle, 1 );
        
        return true;
    }
}