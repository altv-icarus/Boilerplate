using System.Reflection;
using AltV.Atlas.Boilerplate.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// This should only run when EFCore runs (eg migrations, database updates, etc). For starting altV server, Startup.cs should be used.
// This setup contains the minimum required classes and whatnot for EFCore to succeed.
// Check if args contains "database" for efcore stuff. We don't want to run this when eg starting server.
Console.WriteLine( $"cmd args: { string.Join( ", ", Environment.GetCommandLineArgs( ) ) }");
if( Environment.GetCommandLineArgs( ).Contains( "database" ) || Environment.GetCommandLineArgs( ).Contains( "migrations" ) )
{
    var builder = Host.CreateDefaultBuilder( );

    builder
        .UseContentRoot( Path.GetDirectoryName( Assembly.GetExecutingAssembly( ).Location )! )
        .ConfigureServices( ( context, services ) =>
        {
            services.AddOptions( );
            services.RegisterMySqlModule( context );
        } );

    var host = builder.UseConsoleLifetime( ).Build( );
    await host.RunAsync( );
}