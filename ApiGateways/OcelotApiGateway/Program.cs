using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using JwtExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", false, true);
builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddJwtAuthentication();

var app = builder.Build();

app.UseCors("AllowOrigin");

await app.UseOcelot();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
