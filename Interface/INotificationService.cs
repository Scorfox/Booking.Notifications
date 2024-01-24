using Notification.API.Models;

namespace Notification.API.Interface
{
    public interface INotificationService
    {
        public Task SendMailAsync(MailRequest mailRequest);
    }
}
