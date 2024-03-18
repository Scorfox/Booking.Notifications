using Otus.Booking.Common.Booking.NotificationsTemplates.Models;

namespace Booking.Notifications.Domain.Interfaces;

public interface INotificationService
{
    Task<bool> SendMailAsync(string ToMail, string subjecte, string body);
    Task<bool> SendRazorMailAsync(string to, UserCreatedNotificationModel model, CancellationToken token = default);
}
