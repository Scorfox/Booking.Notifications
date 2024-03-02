using AutoMapper;
using Otus.Booking.Common.Booking.Contracts.Notification.Requests;
using Otus.Booking.Common.Booking.Contracts.Notification.Responses;

namespace Booking.Notifications.Application.Mappings
{
    public sealed class NotificationMapper : Profile
    {
        public NotificationMapper()
        {
            CreateMap<SendNotification, Domain.Models.NotificationTamplate>();
            CreateMap<Domain.Models.NotificationTamplate, SendNotificationResult>();
        }
    }
}
