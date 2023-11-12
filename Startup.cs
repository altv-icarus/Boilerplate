using AltV.Net.Async;

namespace AltV.Icarus.Boilerplate;

public class Startup : AsyncResource
{
    private Bootstrapper _bootstrapper;
    
    public override async void OnStart( )
    {
        _bootstrapper = new Bootstrapper( );
        await _bootstrapper.RunAsync( );
    }

    public override void OnStop( )
    {
        throw new NotImplementedException( );
    }
}