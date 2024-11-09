using CruiseManager.Bootstrapper;
using CruiseManager.Shared.Infrastructure;

var assemblies = ModuleLoader.LoadAssemblies();
var modules = ModuleLoader.LoadModules(assemblies);

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddInfrastructure();
// auto registering modules
foreach (var module in modules)
{
    module.Register(services);
}

var app = builder.Build();
app.UseInfrastructure();
// auto configure middleware for modules 
foreach (var module in modules)
{
    module.Use(app);
}

// cleanup
assemblies.Clear();
modules.Clear();

app.Run();
