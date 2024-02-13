namespace Booking.Notifications.Domain.Interfaces;

public interface INotificationService
{
    Task<bool> SendMailAsync(string subjecte, string ToMail);
}
