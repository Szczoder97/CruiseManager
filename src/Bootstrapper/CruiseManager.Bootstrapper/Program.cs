using CruiseManager.Modules.Boats.Api;
using CruiseManager.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddInfrastructure();

// register modules
services.AddBoats();

var app = builder.Build();
app.UseInfrastructure();
app.Run();
