using Booking.Notifications.WebAPI.Options;
using Microsoft.AspNetCore.Mvc;
using Otus.Booking.Common.Booking.NotificationsTemplates.Models;

namespace Booking.Notifications.WebAPI.Extensions
{
    public static class RazorMailConfiguratorExtensions
    {

        public static void ConfigureRazorEmailSender(this IServiceCollection services, [FromServices] MailOptions options)
        {
            services.AddFluentEmail(options.Mail)
                .AddRazorRenderer()
                .AddRazorRenderer(typeof(UserCreatedNotificationModel))
                .AddSmtpSender(options.Host, options.Port, options.Mail, options.Password);

        }
    }


}
