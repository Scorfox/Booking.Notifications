using Booking.Notifications.Application;
using Booking.Notifications.Application.Consumers;
using Booking.Notifications.Application.Repositories;
using Booking.Notifications.Domain.Interfaces;
using Booking.Notifications.Persistence;
using Booking.Notifications.WebAPI.Extensions;
using Booking.Notifications.WebAPI.Options;
using Booking.Notifications.WebAPI.Services;
using MassTransit;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Booking.Notifications.WebAPI;

public class Startup
{
    public IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration) 
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigurePersistence(Configuration);
        services.ConfigureApplication();

        services.ConfigureApiBehavior();
        services.ConfigureCorsPolicy();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.Configure<MailOptions>(Configuration.GetSection("MailSettings"));
        services.ConfigureRazorEmailSender(Configuration.GetSection("MailSettings").Get<MailOptions>()!);

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(Configuration["RabbitMQ:Host"], h =>
                {
                    h.Username(Configuration["RabbitMQ:Username"]);
                    h.Password(Configuration["RabbitMQ:Password"]);
                });
                cfg.ConfigureEndpoints(context);
            });
            x.AddConsumer<CreateUserNotificationConsumer>();
            x.AddConsumer<CreateReservationConsumer>();
            x.AddConsumer<ReservationStatusChangedConsumer>();
        });

        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo {Title = "Notification.API", Version = "v1"});
        });
        
        services.AddScoped<INotificationService, NotificationService>();
        services.Configure<MailOptions>(Configuration.GetSection("MailSettings"));
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        app.UseSerilogRequestLogging();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseErrorHandler();
        app.UseCors();
        app.MapControllers();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}