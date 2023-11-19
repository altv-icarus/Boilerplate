using System.Reflection;
using AltV.Atlas.Chat;
using AltV.Atlas.Commands;
using AltV.Atlas.IoC;
using AltV.Atlas.Peds;
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
            .UseContentRoot( Path.GetDirectoryName( Assembly.GetExecutingAssembly( ).Location )! )
            .ConfigureAppConfiguration( ConfigureAppConfig )
            .ConfigureServices( ConfigureServices );

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

        services.RegisterCommandModule( );
        services.RegisterChatModule( );
        services.RegisterPedModule( );

        var assemblies = AppDomain.CurrentDomain.GetAssemblies( );

        services
            .ScanForAttributeInjection( assemblies )
            .ScanForOptionAttributeInjection( context.Configuration, assemblies );
    }

    public Task RunAsync( )
    {
        _host.Services.ResolveStartupServices( );
        _host.Services.InitializeCommandModule( );
        _host.Services.InitializeChatModule( );

        _logger.LogInformation( "Bootstrapper initiated" );
        Console.WriteLine( "" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( "|                      alt:V MP Atlas Boilerplate started!                     |" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( $"| .NET Version: {Environment.Version.ToString( )}                                                          |" );
        Console.WriteLine( "|------------------------------------------------------------------------------|" );
        Console.WriteLine( "" );
        return _host.RunAsync( );
    }
}
