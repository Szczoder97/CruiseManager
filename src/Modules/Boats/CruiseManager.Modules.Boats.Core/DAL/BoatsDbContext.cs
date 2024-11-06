using Microsoft.EntityFrameworkCore;

namespace CruiseManager.Modules.Boats.Core.DAL;

internal class BoatsDbContext : DbContext
{
    // TODO: boats, shipowners, accessories

    public BoatsDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("boats");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}