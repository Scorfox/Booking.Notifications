using Booking.Notifications.Application;
using Microsoft.OpenApi.Models;
using Booking.Notifications.WebAPI.Extensions;
using Booking.Notifications.Persistence;
using Booking.Notifications.Application.Repositories;
using Booking.Notifications.Persistence.Services;
using Booking.Notifications.WebAPI.Options;
using Booking.Notifications.Domain.Interfaces;
using Booking.Notifications.Persistence.Repositories;
using Booking.Notifications.Persistence.Context;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();

builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQ:Host"], h =>
        {
            h.Username(builder.Configuration["RabbitMQ:Username"]);
            h.Password(builder.Configuration["RabbitMQ:Password"]);
        });
        cfg.ConfigureEndpoints(context);
    });

});

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Notification.API", Version = "v1" });
});

builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.Configure<MailOptions>(builder.Configuration.GetSection("MailSettings"));

var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
dataContext?.Database.EnsureCreated();

app.UseSwagger();
app.UseSwaggerUI();
app.UseErrorHandler();
app.UseCors();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.Run();