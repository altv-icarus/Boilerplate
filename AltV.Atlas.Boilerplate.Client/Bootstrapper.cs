using AltV.Atlas.Client.Configuration;
using AltV.Atlas.KeyInputs.Client;
using AltV.Atlas.Peds.Client;
using AltV.Atlas.Scaleforms.Client;
using AltV.Atlas.Shared.Models;
using AltV.Atlas.Vehicles.Client;
using AltV.Net.Client.Elements.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Boilerplate.Client;

public class Bootstrapper
{
    private IServiceProvider _serviceProvider;
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
        
        _serviceCollection.AddTransient<AppSettings>( x => ConfigurationLoader.Load<AppSettings>( "net6.0/appsettings.json" ) );
        
        #region Free Modules

        // Register ped module - do the same on server-side and peds module will work :)
        _serviceCollection.RegisterPedModule( );
        _serviceCollection.RegisterVehicleModule( );
        _serviceCollection.RegisterScaleformModule( );
        _serviceCollection.RegisterKeyInputModule( );
        #endregion
        
        #region Premium Modules

        //_serviceCollection.RegisterPedTrafficModule( );
        //_serviceCollection.RegisterAdminModule( );

        #endregion
    }

    public void Run( )
    {
        #region Premium Modules

        //_serviceProvider.InitializePedTrafficModule( );
        //_serviceProvider.InitializeAdminModule( );
        _serviceProvider.InitializeScaleformModule( );
        _serviceProvider.InitializeKeyInputModule( new List<Key>{Key.Space, Key.F4} );
        #endregion
        Console.WriteLine( "" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( "|               alt:V MP Atlas Client-side boilerplate started!                |" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( $"| .NET Version: {Environment.Version.ToString( )}                                                          |" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( "" );
    }
}
