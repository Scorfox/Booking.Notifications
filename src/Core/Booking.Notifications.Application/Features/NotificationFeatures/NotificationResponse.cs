namespace Booking.Notifications.Application.Features.NotificationFeatures;

public sealed record NotificationResponse
{
    public string FromEmail { get; set; }
    public string Subjecte { get; set; }
}
