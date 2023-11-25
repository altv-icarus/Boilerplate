using AltV.Atlas.Peds.Client;
using AltV.Atlas.Peds.Traffic.Client;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Boilerplate.Client;

public class Bootstrapper
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IServiceCollection _serviceCollection;

    public Bootstrapper( )
    {
        Console.WriteLine( "Initiating bootstrapper" );

        _serviceCollection = new ServiceCollection( );
        ConfigureServices( );
        
        _serviceProvider = _serviceCollection.BuildServiceProvider( );
    }

    public IServiceProvider Services => _serviceProvider;
    
    private void ConfigureServices( )
    {
        _serviceCollection.AddSingleton( sp => sp );
        
        // Register ped module - do the same on server-side and peds module will work :)
        _serviceCollection.RegisterPedModule( );
        _serviceCollection.RegisterPedTrafficModule( );
    }

    public void Run( )
    {
        _serviceProvider.InitializePedTrafficModule( );
        Console.WriteLine( "" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( "|               alt:V MP Atlas Client-side boilerplate started!                |" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( $"| .NET Version: {Environment.Version.ToString( )}                                                          |" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( "" );
    }
}
