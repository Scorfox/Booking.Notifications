using Booking.Notifications.Domain.Interfaces;
using Booking.Notifications.Domain.NotificationsTemplates;
using MassTransit;
using Otus.Booking.Common.Booking.Notifications.Models;

namespace Booking.Notifications.Application.Consumers;

public class ReservationStatusChangedConsumer: IConsumer<ReservationStatusChangedNotification>
{
    private readonly INotificationService _notificationService;

    public ReservationStatusChangedConsumer(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task Consume(ConsumeContext<ReservationStatusChangedNotification> context)
    {
        var reservation = context.Message;

        switch (reservation.Status)
        {
            case ReservationStatus.Confirmed:
                await _notificationService.SendRazorMailAsync(reservation.Email,
                    UserNotificationsTemplates.ReservationStatusNotification,
                    UserNotificationsTemplates.ReservationCreatedTemplate, reservation);
                break;
            case ReservationStatus.Rejected:
                await _notificationService.SendRazorMailAsync(reservation.Email,
                    UserNotificationsTemplates.ReservationStatusNotification,
                    UserNotificationsTemplates.ReservationCanceledTemplate, reservation);
                break;
            default: throw new Exception($"Not Supported ReservationStatus {reservation.Status}");
        }
    }
}