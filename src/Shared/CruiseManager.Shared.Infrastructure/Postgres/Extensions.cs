using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CruiseManager.Shared.Infrastructure.Postgres;

public static class Extensions
{
    internal static IServiceCollection AddPostgres(this IServiceCollection services)
    {
        var options = services.GetOptions<PostgresOptions>("postgres");
        services.AddSingleton(options);
        return services;
    }

    public static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T : DbContext
    {
        var options = services.GetOptions<PostgresOptions>("postgres");
        services.AddDbContext<T>(c => c.UseNpgsql(options.ConnectionString));
        
        return services;
    }
}