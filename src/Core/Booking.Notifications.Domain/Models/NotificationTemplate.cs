namespace Booking.Notifications.Domain.Models;

public class NotificationTamplate : BaseEntity
{
    public string Subject { get; set; }
    public string Body { get; set; }
}
