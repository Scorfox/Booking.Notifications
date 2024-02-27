using Booking.Notifications.Domain.Models;

namespace Booking.Notifications.Application.Repositories;

public interface INotificationRepository : IBaseRepository<NotificationTamplate>
{
    Task<NotificationTamplate> GetTemplateBySubjecteAsync(string subjecte);
    Task<bool> HasAnyBySubjecteAsync(string subjecte, CancellationToken token = default);
    Task<NotificationTamplate> GetTemplateByIdAsync(Guid id);
    Task<bool> HasAnyByIdAsync(Guid id, CancellationToken token = default);
}
