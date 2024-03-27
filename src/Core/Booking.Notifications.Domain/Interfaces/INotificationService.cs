namespace Booking.Notifications.Domain.Interfaces;

public interface INotificationService
{
    Task<bool> SendRazorMailAsync(string to, string subject, string bodyTemplate, object model, CancellationToken token = default);

}
