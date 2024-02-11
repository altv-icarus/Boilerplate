using AltV.Atlas.Boilerplate.Database.Context;
using AltV.Atlas.Boilerplate.Database.Factories;
using AltV.Atlas.Boilerplate.Database.Features.Users.Interfaces;
using AltV.Atlas.Boilerplate.Database.Features.Users.Services;
using AltV.Atlas.Database.Shared.Interfaces;
using AltV.Atlas.Database.Shared.Repositories;
using AltV.Atlas.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AltV.Atlas.Boilerplate.Database;

public static class BoilerplateDatabaseModule
{
    private static IServiceCollection RegisterGenericDatabaseServices( this IServiceCollection serviceCollection )
    {
        serviceCollection.AddTransient( typeof( IAtlasRepository<,> ), typeof( AtlasRepository<,> ) );
        serviceCollection.AddTransient( typeof( PasswordHasher<> ) );
        serviceCollection.AddTransient<IUserService, UserService>( );
        return serviceCollection;
    }
    
    public static IServiceCollection RegisterMySqlModule( this IServiceCollection serviceCollection, HostBuilderContext context )
    {
        serviceCollection.RegisterGenericDatabaseServices( );
        
        var dbSettingsSection = context.Configuration.GetSection( DatabaseSettings.Key );
        serviceCollection.Configure<DatabaseSettings>( dbSettingsSection );
        var dbSettings = dbSettingsSection.Get<DatabaseSettings>( )!;
        
        serviceCollection.AddDbContextFactory<AtlasDbContext, DatabaseContextFactory>(options =>
        {
            #region MySql related - can be skipped for other database engines
            options.UseMySql( dbSettings.ConnectionString, ServerVersion.AutoDetect( dbSettings.ConnectionString ) );
            #endregion
            
#if DEBUG
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
#endif
        });
        
        return serviceCollection;
    }
}