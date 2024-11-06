using CruiseManager.Shared.Infrastructure.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using CruiseManager.Shared.Infrastructure.Exceptions;

[assembly: InternalsVisibleTo("CruiseManager.Bootstrapper")]
namespace CruiseManager.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddExceptionHandling();
            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

            return services;
        }

        public static WebApplication UseInfrastructure(this WebApplication app)
        {
            app.UseExceptionHandling();
            app.MapControllers();

            return app;
        }
    }
}
