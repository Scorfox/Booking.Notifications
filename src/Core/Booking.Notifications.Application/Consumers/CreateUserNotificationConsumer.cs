using Booking.Notifications.Domain.Interfaces;
using MassTransit;
using Otus.Booking.Common.Booking.Contracts.User.Requests;
using Otus.Booking.Common.Booking.NotificationsTemplates.Models;

namespace Booking.Notifications.Application.Consumers
{
    public class CreateUserNotificationConsumer:IConsumer<CreateUserNotification>
    {
        private readonly INotificationService _notificationService;

        public CreateUserNotificationConsumer(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Consume(ConsumeContext<CreateUserNotification> context)
        {
            var request = context.Message;
            
            await _notificationService.SendRazorMailAsync(request.Email, new UserCreatedNotificationModel
            {
                LastName = request.LastName,
                Login = request.Login,
                Name = request.FirstName
            });


        }
    }


}
