using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using CruiseManager.Modules.Boats.Core.DAL;
using CruiseManager.Shared.Infrastructure.Postgres;

[assembly: InternalsVisibleTo("CruiseManager.Modules.Boats.Api")]
namespace CruiseManager.Modules.Boats.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddPostgres<BoatsDbContext>();
            return services;
        }
    }
}
