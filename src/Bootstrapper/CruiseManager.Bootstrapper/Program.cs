using CruiseManager.Bootstrapper;
using CruiseManager.Shared.Infrastructure;
using CruiseManager.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureModules();

var services = builder.Services;

var assemblies = ModuleLoader.LoadAssemblies(builder.Configuration);
var modules = ModuleLoader.LoadModules(assemblies);

services.AddInfrastructure(assemblies, modules);
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
