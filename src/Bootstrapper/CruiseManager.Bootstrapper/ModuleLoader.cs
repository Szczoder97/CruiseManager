using System.Reflection;
using CruiseManager.Shared.Abstractions.Modules;

namespace CruiseManager.Bootstrapper;

internal static class ModuleLoader
{
    public static IList<Assembly> LoadAssemblies( IConfiguration configuration)
    {
        const string modulePart = "CruiseManager.Modules.";
        
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var locations = assemblies.Where(a => !a.IsDynamic).Select(a => a.Location).ToArray();
        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase))
            .ToList();
        
        var disabledModules = new List<string>();
        foreach (var file in files)
        {
            if (!file.Contains(modulePart))
            {
                continue;
            }
            
            var moduleName = file.Split(modulePart)[1].Split(".")[0];
            var enabled = configuration.GetValue<bool>($"{moduleName}:module:enabled");

            if (!enabled)
            {
                disabledModules.Add(file);
            }
        }

        foreach (var dm in disabledModules)
        {
            files.Remove(dm);
        }
        
        files.ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));

        return assemblies;
    }

    public static IList<IModule> LoadModules(IEnumerable<Assembly> assemblies)
        => assemblies.SelectMany(a => a.GetTypes())
            .Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsInterface)
            .OrderBy(t => t.Name)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();

}