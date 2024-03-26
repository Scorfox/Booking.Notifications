using Booking.Notifications.Domain.Interfaces;
using Booking.Notifications.Domain.NotificationsTemplates;
using MassTransit;
using Otus.Booking.Common.Booking.Notifications.Models;

namespace Booking.Notifications.Application.Consumers
{
    public class CreateReservationConsumer:IConsumer<ReservationCreatedNotification>
    {
        private readonly INotificationService _notificationService;

        public CreateReservationConsumer(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Consume(ConsumeContext<ReservationCreatedNotification> context)
        {
            var reservation = context.Message;

            await _notificationService.SendRazorMailAsync(reservation.Email,
                UserNotificationsTemplates.ReservationCreatedSubjectTemplate,
                UserNotificationsTemplates.ReservationCreatedTemplate, reservation);
        }
    }
}
