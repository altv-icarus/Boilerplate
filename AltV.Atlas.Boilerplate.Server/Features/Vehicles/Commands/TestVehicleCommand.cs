using AltV.Atlas.Boilerplate.Server.Features.Commands.Extensions;
using AltV.Atlas.Vehicles.Server.Entities;
using AltV.Atlas.Vehicles.Server.Enums;
using AltV.Atlas.Vehicles.Server.Interfaces;
using AltV.Atlas.Vehicles.Server.Models;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using Microsoft.Extensions.Logging;

namespace AltV.Atlas.Boilerplate.Server.Features.Vehicles.Commands;

public class TestVehicleCommand( ILogger<SpawnVehicleCommand> logger ) : IExtendedCommand
{
    private readonly ILogger<SpawnVehicleCommand> _logger = logger;

    public string Name { get; set; } = "testvehicle";
    public string[ ]? Aliases { get; set; } = new[ ] { "tv" };
    public string Description { get; set; } = "Runs a test command";
    public uint RequiredLevel { get; set; } = 0;
    public string HelpText { get; set; } = "/testvehicle";

    public void OnCommand( IPlayer player )
    {
        if( !player.IsInVehicle )
        {
            return;
        }

        if( player.Vehicle is not AtlasTuningVehicle veh )
            return;
        
        veh.SetPrimaryMaterial( EColorMaterial.Matte );
        veh.SetSecondaryMaterial( EColorMaterial.Matte );

        veh.SetWheelColor( EGtaColor.Blue );
        veh.SetHeadlightColor( EHeadlightColor.Turquoise );
        veh.SetTireSmokeRgb( "#15dbfc" );
        veh.SetNeonColorRgb( "#15dbfc" );
        veh.SetNeonStyle( ENeonStyle.LeftRightTopBack );
        veh.InstallMod( new VehicleMod
        {
            ModType = VehicleModType.Spoilers,
            Index = 24
        } );
    }
}