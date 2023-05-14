using MassTransit;
using Member.API.EventBusConsumer;
using Microsoft.Extensions.Options;
using PMTDataAccess.Data;
using PMTDataAccess.Models;
using PMTDataAccess.Repositories;
using PMTDataAccess.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.Configure<MongoDBSettings>(configuration.GetSection("MongoDatabaseSettings"));
builder.Services.AddSingleton<IMongoDBSettings>(provider => provider.GetRequiredService<IOptions<MongoDBSettings>>().Value);

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<AssignTaskConsumer>();
    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(configuration.GetValue<string>("RabbitMq:HostAddress"));
        cfg.ReceiveEndpoint(EventBus.Messages.Common.Constants.TaskAssignmentQueue, c => { 
            c.ConfigureConsumer<AssignTaskConsumer>(ctx);
        });
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
builder.Services.AddControllers();

builder.Services.AddTransient<IDbContext, DbContext>();
builder.Services.AddTransient<IProjectTaskRepository, ProjectTaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();