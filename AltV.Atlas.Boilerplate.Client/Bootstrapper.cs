﻿using System.Text.Json;
using AltV.Atlas.Client.Configuration;
using AltV.Atlas.Peds.Client;
using AltV.Atlas.Peds.Traffic.Client;
using AltV.Atlas.Shared.Converters;
using AltV.Atlas.Shared.Models;
using AltV.Net.Client;
using Microsoft.Extensions.Configuration;
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
