using AltV.Atlas.Boilerplate.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace AltV.Atlas.Boilerplate.Database.Factories;

public class DatabaseContextFactory : IDbContextFactory<AtlasDbContext>
{
    private readonly DbContextOptions<AtlasDbContext> _options;

    public DatabaseContextFactory(DbContextOptions<AtlasDbContext> options)
    {
        _options = options;
    }

    public AtlasDbContext CreateDbContext() => new(_options);
}