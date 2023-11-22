using AltV.Atlas.Vehicles.AltV.Entities;
using AltV.Atlas.Vehicles.Entities;
using AltV.Atlas.Vehicles.Interfaces;
using AltV.Net;
using AltV.Net.Elements.Entities;
using Microsoft.Extensions.Logging;

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