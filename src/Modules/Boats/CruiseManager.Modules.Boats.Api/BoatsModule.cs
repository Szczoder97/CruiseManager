using CruiseManager.Modules.Boats.Core;
using CruiseManager.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CruiseManager.Modules.Boats.Api;

internal class BoatsModule : IModule
{
    public const string BasePath = "boats-module";
    
    public string Name { get; } = "boats";
    public string Path => BasePath;
    
    public void Register(IServiceCollection services)
    {
        services.AddCore();
    }

    public void Use(IApplicationBuilder app)
    {
    }
}