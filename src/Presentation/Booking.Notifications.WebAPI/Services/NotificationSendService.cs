using AutoMapper.Internal;
using Booking.Notifications.Application.Repositories;
using Booking.Notifications.Domain.Models;
using Booking.Notifications.WebAPI.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Booking.Notifications.Persistence.Services;

public class NotificationSendService : INotificationRepository
{
    private readonly MailOptions _mailOptions;

    public NotificationSendService(IOptions<MailOptions> mailOptions)
    {
        _mailOptions = mailOptions.Value;
    }

    public async Task SendMailAsync(MailRequest mailRequest)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_mailOptions.Mail);
        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        email.Subject = mailRequest.Subject;
        var builder = new BodyBuilder();
        if (mailRequest.Attachments != null)
        {
            byte[] filebytes;
            foreach (var file in mailRequest.Attachments)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        filebytes = ms.ToArray();
                    }
                    builder.Attachments.Add(file.Name, filebytes, ContentType.Parse(file.ContentType));
                }
            }
        }

        builder.HtmlBody = mailRequest.Body;
        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        smtp.Connect(_mailOptions.Host, _mailOptions.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_mailOptions.Mail, _mailOptions.Password);
        await smtp.SendAsync(email);
        smtp.Dispose();
    }
}
