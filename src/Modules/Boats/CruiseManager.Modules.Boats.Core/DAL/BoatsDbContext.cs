using CruiseManager.Modules.Boats.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CruiseManager.Modules.Boats.Core.DAL;

internal class BoatsDbContext : DbContext
{
    // TODO: shipowners, accessories
    private DbSet<Boat> Boats { get; set; }

    public BoatsDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("boats");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}