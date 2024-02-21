using Booking.Notifications.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Notifications.Application.EntityTypeConfigurations
{
    public class TamplateMailEntityTypeConfiguration : IEntityTypeConfiguration<NotificationTamplate>
    {
        public void Configure(EntityTypeBuilder<NotificationTamplate> builder)
        {
            builder.HasIndex(i => i.Subject)
                .IsUnique();
        }

    }
}
