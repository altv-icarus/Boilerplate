using AltV.Atlas.Vehicles.Server.AltV.Entities;
using AltV.Net;

namespace AltV.Atlas.Boilerplate.Server.Features.Vehicles.Overrides;

public class ExtendedVehicle : AtlasVehicleBase
{
    public string NumberPlate
    {
        set => NumberplateText = value;
    }

    public ExtendedVehicle( ICore core, IntPtr nativePointer, uint id ) : base( core, nativePointer, id )
    {
        Console.WriteLine( "ITS AN EXTENDED VEHICLE!" );
    }
}