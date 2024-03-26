using AutoMapper.Internal;
using Booking.Notifications.Application.Repositories;
using Booking.Notifications.Domain.Interfaces;
using Booking.Notifications.Domain.NotificationsTemplates;
using Booking.Notifications.WebAPI.Options;
using FluentEmail.Core;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Otus.Booking.Common.Booking.Notifications.Models;
using Serilog.Core;


namespace Booking.Notifications.Persistence.Services;

public class NotificationService : INotificationService
{
    private readonly MailOptions _mailOptions;
    private readonly IFluentEmail _emaiSender;
    private readonly ILogger<NotificationService> _logger;
    
    public NotificationService(IOptions<MailOptions> mailOptions, IFluentEmail email, ILogger<NotificationService> logger)
    {
        _mailOptions = mailOptions.Value;
        _emaiSender = email;
        _logger = logger;
    }
    [Obsolete("Use send razor async", true)]
    public async Task<bool> SendMailAsync(string ToMail, string subjecte, string body)
    {
        try
        {
            var email = new MimeMessage();

            email.Sender = MailboxAddress.Parse(_mailOptions.Mail);
            email.To.Add(MailboxAddress.Parse(ToMail));
            email.Subject = subjecte;

            var builder = new BodyBuilder();
            builder.HtmlBody = body;
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

    public async Task<bool> SendRazorMailAsync(string to, string subject, string bodyTemplate, object model, CancellationToken token = default)
    {
        try
        {
            var email = _emaiSender.To(to)
                .Subject(subject)
                .UsingTemplate(bodyTemplate, model);
            await email.SendAsync(token);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Can't send mail");
            return false;
        }
    }

}
