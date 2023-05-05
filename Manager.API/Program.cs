using Manager.API.Data;
using Manager.API.Repositories.Interfaces;
using Manager.API.Repositories;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Manager.API.Models;
using Manager.API.Utilities;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

//var factory = new ConnectionFactory
//{
//    HostName = "localhost"
//};

//var connection = factory.CreateConnection();
////Here we create channel with session and model

//var channel = connection.CreateModel();
////declare the queue after mentioning name and a few property related to that
//channel.QueueDeclare("AssigningTasksQueue", exclusive: false);
//Set Event object which listen message from chanel which is sent by producer
//var consumer = new EventingBasicConsumer(channel);
//consumer.Received += (model, eventArgs) => {
//    var body = eventArgs.Body.ToArray();
//    var message = Encoding.UTF8.GetString(body);
//    Console.WriteLine($"AssigningTasksQueue message received: {message}");
//};
////read the message
//channel.BasicConsume(queue: "AssigningTasksQueue", autoAck: true, consumer: consumer);

builder.Services.Configure<RabbitMqConfiguration>(configuration.GetSection("RabbitMq"));
builder.Services.AddScoped<ISendAssigningTask, SendAssigningTask>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("Cors", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
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

