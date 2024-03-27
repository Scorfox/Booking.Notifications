using Booking.Notifications.Domain.Interfaces;
using FluentEmail.Core;
using Serilog;

namespace Booking.Notifications.WebAPI.Services;

public class NotificationService : INotificationService
{
    private readonly IFluentEmail _emailSlender;
    
    public NotificationService(IFluentEmail email)
    {
        _emailSlender = email;
    }

    public async Task<bool> SendRazorMailAsync(string to, string subject, string bodyTemplate, object model, CancellationToken token = default)
    {
        try
        {
            var email = _emailSlender.To(to)
                .Subject(subject)
                .UsingTemplate(bodyTemplate, model);
            await email.SendAsync(token);
            return true;
        }
        catch (Exception e)
        {
            Log.Error(e, "Can't send mail");
            return false;
        }
    }
}
