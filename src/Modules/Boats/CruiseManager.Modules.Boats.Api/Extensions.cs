using CruiseManager.Modules.Boats.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CruiseManager.Bootstrapper")]
namespace CruiseManager.Modules.Boats.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddBoats(this IServiceCollection services)
        {
            services.AddCore();
            return services;
        }
    }
}
