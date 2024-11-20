using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace CruiseManager.Shared.Infrastructure.Modules;

public static class Extensions
{
    internal static WebApplicationBuilder ConfigureModules(this WebApplicationBuilder builder)
    {
        var env = builder.Environment;
        var configuration = builder.Configuration;
        
        foreach (var settings in GetSettings("*"))
        {
            configuration.AddJsonFile(settings);
        }
        
        foreach (var settings in GetSettings($"*.{env.EnvironmentName}"))
        {
            configuration.AddJsonFile(settings);
        }
        
        IEnumerable<string> GetSettings(string pattern)
            => Directory.EnumerateFiles(env.ContentRootPath,
                $"module.{pattern}.json", SearchOption.AllDirectories);
        
        return builder;
    }
}