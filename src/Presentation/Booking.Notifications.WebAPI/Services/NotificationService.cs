using AutoMapper.Internal;
using Booking.Notifications.Application.Repositories;
using Booking.Notifications.Domain.Interfaces;
using Booking.Notifications.WebAPI.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Booking.Notifications.Persistence.Services;

public class NotificationService : INotificationService
{
    private readonly MailOptions _mailOptions;
    private readonly INotificationRepository _notificationRepository;

    public NotificationService(IOptions<MailOptions> mailOptions)
    {
        _mailOptions = mailOptions.Value;
    }

    public async Task<bool> SendMailAsync(string templateId, string ToMail)
    {
        try
        {
            var email = new MimeMessage();
            var dataTemplate = await _notificationRepository.GetTemplateByIdAsync(templateId, default);

            email.Sender = MailboxAddress.Parse(_mailOptions.Mail);
            email.To.Add(MailboxAddress.Parse(ToMail));
            email.Subject = dataTemplate.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = dataTemplate.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailOptions.Host, _mailOptions.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailOptions.Mail, _mailOptions.Password);
            await smtp.SendAsync(email);
            smtp.Dispose();
            return true;
        } 
        catch { return false; }
    }
}
