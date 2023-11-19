using AltV.Net.Client;
using AltV.Net.Client.Async;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Boilerplate.Client;

public class Startup : AsyncResource
{
    private Bootstrapper _bootstrapper;

    public Startup()
    {
        _bootstrapper = new Bootstrapper(  );
    }

    public override void OnStart( )
    {
        _bootstrapper.Run( );
    }

    public override void OnStop( )
    {
        throw new NotImplementedException( );
    }
    
    public override IEntityFactory<IPed> GetPedFactory( )
    {
        Alt.Log( "GetPedFactory" );
        return _bootstrapper.Services.GetService<IEntityFactory<IPed>>( )!;
    }
}