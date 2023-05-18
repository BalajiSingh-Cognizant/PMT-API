using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Authentication.API;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", false, true);
builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddJwtAuthentication();


var app = builder.Build();

await app.UseOcelot();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
