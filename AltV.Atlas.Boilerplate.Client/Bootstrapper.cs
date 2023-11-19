using AltV.Atlas.Client.DependencyInjection;
using AltV.Atlas.Peds.Client;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Boilerplate.Client;

public class Bootstrapper
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IServiceCollection _serviceCollection;
    private readonly Logger<Bootstrapper> _logger;

    public Bootstrapper( )
    {
        Console.WriteLine( "Initiating bootstrapper" );

        _serviceCollection = new ServiceCollection( );
        ConfigureServices( );
        
        _serviceProvider = _serviceCollection.BuildServiceProvider( );
        _logger = _serviceProvider.GetService<Logger<Bootstrapper>>( )!;
    }

    public IServiceProvider Services => _serviceProvider;
    
    private void ConfigureServices( )
    {
        _serviceCollection.AddTransient<Logger<Bootstrapper>>( );
        _serviceCollection.AddSingleton( sp => sp );

        _serviceCollection.RegisterPedModule( );
    }

    public void Run( )
    {
        _serviceProvider.ResolveStartupServices( );
        
        _logger.LogInformation( "Bootstrapper initiated" );
        Console.WriteLine( "" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( "|               alt:V MP Atlas Client-side boilerplate started!                |" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( $"| .NET Version: {Environment.Version.ToString( )}                                                          |" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( "" );
    }
}
