using Booking.Notifications.Domain.Models;

namespace Booking.Notifications.Application.Repositories;

public interface INotificationRepository
{
    public Task SendMailAsync(MailRequest mailRequest);
}
