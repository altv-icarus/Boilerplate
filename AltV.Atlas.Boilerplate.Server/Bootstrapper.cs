using System.Reflection;
using AltV.Atlas.Boilerplate.Server.Features.Vehicles.Overrides;
using AltV.Atlas.Chat;
using AltV.Atlas.Commands;
using AltV.Atlas.IoC;
using AltV.Atlas.Peds;
using AltV.Atlas.Peds.Traffic.Server;
using AltV.Atlas.Vehicles.Server;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AltV.Atlas.Boilerplate.Server;

public class Bootstrapper
{
    private readonly IHost _host;
    private readonly ILogger<Bootstrapper> _logger;

    public Bootstrapper( )
    {
        Console.WriteLine( "Initiating bootstrapper" );
        var builder = Host.CreateDefaultBuilder( );

        builder
            .UseContentRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!)
            .ConfigureAppConfiguration(ConfigureAppConfig)
            .ConfigureServices(ConfigureServices)
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });

        _host = builder.UseConsoleLifetime( ).Build( );
        _logger = _host.Services.GetService<ILogger<Bootstrapper>>( )!;
    }

    public IServiceProvider Services => _host.Services;

    private void ConfigureAppConfig( HostBuilderContext context, IConfigurationBuilder configBuilder )
    {
        configBuilder.AddEnvironmentVariables( "ATLAS_" );
    }

    private void ConfigureServices( HostBuilderContext context, IServiceCollection services )
    {
        services.AddOptions( );
        services.AddSingleton( sp => sp );
        
        #region Free Modules
        services.RegisterCommandModule( );
        services.RegisterChatModule( );
        services.RegisterPedModule( );
        services.RegisterVehicleModule<ExtendedVehicleFactory>( );
        // services.RegisterKeyInputModule( );

        //Not working yet
        //services.RegisterMySqlModule( context );
        #endregion
        
        #region Premium Modules

        services.RegisterPedTrafficModule( ); // https://altv-atlas.github.io/docs/articles/ped-traffic-module.html

        #endregion
        
        services.AddTransient<ExtendedVehicle>( );
        
        var assemblies = AppDomain.CurrentDomain.GetAssemblies( );

        services
            .ScanForAttributeInjection( assemblies )
            .ScanForOptionAttributeInjection( context.Configuration, assemblies );
    }

    public Task RunAsync( )
    {
        _host.Services.ResolveStartupServices( );
        #region Free Modules
        _host.Services.InitializeCommandModule( );
        _host.Services.InitializeChatModule( );
        // _host.Services.InitializeKeyInputModule( );
        #endregion
        
        #region Premium Modules

        _host.Services.InitializePedTrafficModule( ); // https://altv-atlas.github.io/docs/articles/ped-traffic-module.html

        #endregion
        
        Console.WriteLine( "" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( "|                      alt:V MP Atlas Boilerplate started!                     |" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( $"| .NET Version: {Environment.Version.ToString( )}                                                          |" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( "" );
        
        _logger.LogInformation( "Bootstrapper initiated" );
        return _host.RunAsync( );
    }
}
