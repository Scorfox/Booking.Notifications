using Booking.Notifications.Application.Repositories;
using Booking.Notifications.Domain.Models;
using Booking.Notifications.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Xml.Linq;

namespace Booking.Notifications.Persistence.Repositories;

public class NotificationRepository(DataContext context) : BaseRepository<NotificationTamplate>(context), INotificationRepository
{
    public async Task<NotificationTamplate> GetTemplateBySubjecteAsync(string subjecte, CancellationToken cancellationToken)
    {
        return await context.NotificationTemplates.SingleAsync(x => x.Subject == subjecte, cancellationToken);
    }

    public async Task<NotificationTamplate> GetTemplateByIdAsync(string TemplateId, CancellationToken cancellationToken)
    {
        return await context.NotificationTemplates.SingleAsync(x => x.Id == Guid.Parse(TemplateId), cancellationToken);
    }
}
