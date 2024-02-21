using Booking.Notifications.Application.Repositories;
using Booking.Notifications.Persistence.Context;
using Booking.Notifications.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Notifications.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgreSQL");
        
        services.AddDbContext<DataContext>(opt => { opt.UseNpgsql(connectionString); });
        services.AddTransient<INotificationRepository, NotificationRepository>();
    }
}