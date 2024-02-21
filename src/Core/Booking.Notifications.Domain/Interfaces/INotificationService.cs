namespace Booking.Notifications.Domain.Interfaces;

public interface INotificationService
{
    Task<bool> SendMailAsync(string ToMail, string subjecte, string body);
}
