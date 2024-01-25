using Booking.Notifications.Application;
using Microsoft.OpenApi.Models;
using Booking.Notifications.WebAPI.Extensions;
using Booking.Notifications.Persistence;
using Booking.Notifications.Domain.Models;
using System.Configuration;
using Booking.Notifications.Application.Repositories;
using Booking.Notifications.Persistence.Services;
using Booking.Notifications.WebAPI.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence(builder.Configuration);
//builder.Services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
builder.Services.ConfigureApplication();

builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Notification.API", Version = "v1" });
});

builder.Services.AddTransient<INotificationRepository, NotificationSendService>();
builder.Services.Configure<MailOptions>(builder.Configuration.GetSection(MailOptions.Key));

var app = builder.Build();

var serviceScope = app.Services.CreateScope();

app.UseSwagger();
app.UseSwaggerUI();
app.UseErrorHandler();
app.UseCors();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.Run();