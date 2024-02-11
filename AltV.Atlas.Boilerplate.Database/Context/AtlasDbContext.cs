using AltV.Atlas.Boilerplate.Database.Features.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace AltV.Atlas.Boilerplate.Database.Context;

public class AtlasDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public AtlasDbContext(DbContextOptions<AtlasDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");
    }
}
