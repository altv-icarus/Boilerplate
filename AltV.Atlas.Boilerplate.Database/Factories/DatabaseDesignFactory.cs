using System.IO;
using AltV.Atlas.Boilerplate.Database.Context;
using AltV.Atlas.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AltV.Atlas.Boilerplate.Database.Factories;

public class DatabaseDesignFactory : IDesignTimeDbContextFactory<AtlasDbContext>
{
    public AtlasDbContext CreateDbContext( string[ ] args )
    {
        var configuration = new ConfigurationBuilder( )
            .SetBasePath( Directory.GetCurrentDirectory( ) )
            .AddJsonFile( $"appsettings.json" )
            .Build( );

        var dbSettings = configuration.GetSection( DatabaseSettings.Key ).Get<DatabaseSettings>( )!;

        var options = new DbContextOptionsBuilder<AtlasDbContext>( )
            .UseMySql( dbSettings.ConnectionString, ServerVersion.AutoDetect( dbSettings.ConnectionString ) )
            .EnableSensitiveDataLogging( )
            .Options;

        return new AtlasDbContext( options );
    }
}