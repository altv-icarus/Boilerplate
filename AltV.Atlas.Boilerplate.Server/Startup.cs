using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Boilerplate.Server;

public class Startup : AsyncResource
{
    private Bootstrapper _bootstrapper;

    public Startup( )
    {
        _bootstrapper = new Bootstrapper( );
    }

    public override async void OnStart( )
    {
        await _bootstrapper.RunAsync( );
    }

    public override void OnStop( )
    {
        throw new NotImplementedException( );
    }

    public override IEntityFactory<IPed> GetPedFactory( )
    {
        return _bootstrapper.Services.GetService<IEntityFactory<IPed>>( )!;
    }
}