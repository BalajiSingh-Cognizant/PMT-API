using PMTDataAccess.Data;
using PMTDataAccess.Models;
using Manager.API.Utilities;
using PMTDataAccess.Repositories;
using PMTDataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.Configure<MongoDBSettings>(configuration.GetSection("MongoDatabaseSettings"));
builder.Services.AddSingleton<IMongoDBSettings>(provider=>provider.GetRequiredService<IOptions<MongoDBSettings>>().Value);

//builder.Services.Configure<RabbitMqConfiguration>(configuration.GetSection("RabbitMq"));
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(configuration.GetValue<string>("RabbitMq:HostAddress"));
    });
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddCors(o => o.AddPolicy("Cors", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISendAssigningTask, SendAssigningTask>();
builder.Services.AddTransient<IDbContext, DbContext>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();

