using Microsoft.AspNetCore.Http;

namespace Booking.Notifications.Domain.Models;

public class MailRequest
{
    public string ToEmail { get; set; }

    public string FromEmail { get; set; }

    public string Subject { get; set; }

    public string Body { get; set; }

    public List<IFormFile> Attachments { get; set; }
}
