using Booking.Notifications.Application.Repositories;
using Booking.Notifications.Domain.Models;
using Booking.Notifications.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Xml.Linq;

namespace Booking.Notifications.Persistence.Repositories;

public class NotificationRepository(DataContext context) : BaseRepository<NotificationTamplate>(context), INotificationRepository
{
    public async Task<NotificationTamplate> GetTemplateBySubjecteAsync(string subjecte)
    {
        return await context.NotificationTemplates.SingleOrDefaultAsync(x => x.Subject == subjecte);
    }

    public async Task<NotificationTamplate> GetTemplateByIdAsync(Guid TemplateId)
    {
        return await context.NotificationTemplates.SingleOrDefaultAsync(x => x.Id == TemplateId);
    }

    public Task<bool> HasAnyBySubjecteAsync(string subjecte, CancellationToken token = default)
    {
        return Context.NotificationTemplates
            .AnyAsync(x => x.Subject == subjecte);
    }

    public Task<bool> HasAnyByIdAsync(Guid id, CancellationToken token = default)
    {
        return Context.NotificationTemplates
            .AnyAsync(x => x.Id == id);
    }
}
