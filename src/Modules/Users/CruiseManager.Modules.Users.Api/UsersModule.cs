using CruiseManager.Modules.Users.Core;
using CruiseManager.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CruiseManager.Modules.Users.Api;

internal class UsersModule : IModule
{
    public const string BasePath = "users-module";
    public string Name { get; } = "Users";
    public string Path => BasePath;
    public void Register(IServiceCollection services)
    {
        services.AddCore();
    }

    public void Use(IApplicationBuilder app)
    {
    }
}