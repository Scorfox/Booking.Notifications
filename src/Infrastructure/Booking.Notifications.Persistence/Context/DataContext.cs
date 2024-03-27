using Microsoft.EntityFrameworkCore;

namespace Booking.Notifications.Persistence.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}