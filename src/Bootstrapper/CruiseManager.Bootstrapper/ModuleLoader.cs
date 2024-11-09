using System.Reflection;
using CruiseManager.Shared.Abstractions.Modules;

namespace CruiseManager.Bootstrapper;

internal static class ModuleLoader
{
    public static IList<Assembly> LoadAssemblies()
    {
        var assembilies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var locations = assembilies.Where(a => !a.IsDynamic).Select(a => a.Location).ToArray();
        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase))
            .ToList();
        files.ForEach(x => assembilies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));

        return assembilies;
    }

    public static IList<IModule> LoadModules(IEnumerable<Assembly> assemblies)
        => assemblies.SelectMany(a => a.GetTypes())
            .Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsInterface)
            .OrderBy(t => t.Name)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();

}