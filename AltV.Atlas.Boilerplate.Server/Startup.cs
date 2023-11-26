using AltV.Atlas.Vehicles.AltV.Interfaces;
using AltV.Atlas.Vehicles.Interfaces;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Boilerplate.Server;

public class Startup : AsyncResource
{
    private Lazy<Bootstrapper> _bootstrapper = new();


    public override async void OnStart( )
    {
        await _bootstrapper.Value.RunAsync( );
    }

    public override void OnStop( )
    {
        throw new NotImplementedException( );
    }

    public override IEntityFactory<IPed> GetPedFactory( )
    {
        return _bootstrapper.Value.Services.GetService<IEntityFactory<IPed>>( )!;
    }

    public override IEntityFactory<IVehicle> GetVehicleFactory( )
    {
        return _bootstrapper.Value.Services.GetService<IEntityFactory<IAtlasVehicle>>( )!;
    }
}