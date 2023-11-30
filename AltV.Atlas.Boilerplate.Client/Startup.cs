using AltV.Net.Client;
using AltV.Net.Client.Async;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Boilerplate.Client;

public class Startup : AsyncResource
{
    private Lazy<Bootstrapper> _bootstrapper = new();
    
    public override void OnStart( )
    {
        _bootstrapper.Value.Run( );
    }

    public override void OnStop( )
    {
        
    }
    
    public override IEntityFactory<IPed> GetPedFactory( )
    {
        return _bootstrapper.Value.Services.GetService<IEntityFactory<IPed>>( )!;
    }

    public override IEntityFactory<IVehicle> GetVehicleFactory( )
    {
        return _bootstrapper.Value.Services.GetService<IEntityFactory<IVehicle>>( )!;
    }
}