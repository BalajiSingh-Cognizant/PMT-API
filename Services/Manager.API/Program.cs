using PMTDataAccess.Data;
using PMTDataAccess.Models;
using Manager.API.Utilities;
using PMTDataAccess.Repositories;
using PMTDataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

//ConfigurationProvider configurationProvider = new ConfigurationProvider();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

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

app.UseCors("AllowOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

