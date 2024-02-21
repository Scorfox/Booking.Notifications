using Booking.Notifications.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Notifications.Persistence.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<NotificationTamplate> NotificationTemplates { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        FillDefaultData(modelBuilder);
    }

    private static void FillDefaultData(ModelBuilder builder)
    {
        builder.Entity<NotificationTamplate>().HasData(new NotificationTamplate
        {
            Id = Guid.NewGuid(),
            Subject = "Подтверждение вашего бронирования",
            Body = "Здравствуйте [Имя клиента],\r\nМы рады подтвердить ваше бронирование на [дату] в [время] в нашем ресторане. Ваш столик зарезервирован на [количество человек].\r\n\r\nС уважением,\r\n[Имя ресторана]"
        });

        builder.Entity<NotificationTamplate>().HasData(new NotificationTamplate
        {
            Id = Guid.NewGuid(),
            Subject = "Напоминание о вашем бронировании",
            Body = "Здравствуйте [Имя клиента],\r\nХотим напомнить вам о вашем предстоящем бронировании на [дату] в [время] в нашем уютном кофейном доме. Мы ждем вас и вашу компанию!\r\n\r\nС уважением,\r\n[Имя ресторана]"
        });

        builder.Entity<NotificationTamplate>().HasData(new NotificationTamplate
        {
            Id = Guid.NewGuid(),
            Subject = "Спасибо за ваше посещение",
            Body = "Здравствуйте [Имя клиента],\r\nБлагодарим вас за то, что выбрали наш ресторан для вашего вечера. Мы надеемся, что вы насладились атмосферой и кухней нашего заведения. Ждем вас снова!\r\n\r\nС уважением,\r\n[Имя ресторана]"
        });
    }
}