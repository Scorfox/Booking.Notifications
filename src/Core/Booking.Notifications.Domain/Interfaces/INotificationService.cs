


using Otus.Booking.Common.Booking.Notifications.Models;

namespace Booking.Notifications.Domain.Interfaces;

public interface INotificationService
{
    Task<bool> SendMailAsync(string ToMail, string subjecte, string body);
    Task<bool> SendRazorMailAsync(string to, string subject, string bodyTemplate, object model, CancellationToken token = default);

}
