using AutoMapper;
using Booking.Notifications.Application.Exceptions;
using Booking.Notifications.Application.Features.NotificationFeatures;
using Booking.Notifications.Application.Repositories;
using MassTransit;
using MediatR;
using Otus.Booking.Common.Booking.Contracts.Notification.Requests;
using Otus.Booking.Common.Booking.Contracts.Notification.Responses;

namespace Booking.Notifications.Application.Consumers
{
    public sealed class SendNotificationConsumer : IConsumer<SendNotification>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public SendNotificationConsumer(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<SendNotification> context)
        {
            var request = context.Message;

            if (!await _notificationRepository.HasAnyByIdAsync(request.TemplateId, default))
                throw new NotFoundException($"Template {request.TemplateId} not found");

            var mail = await _notificationRepository.GetTemplateByIdAsync(request.TemplateId);

            await context.RespondAsync(_mapper.Map<SendNotificationResult>(mail));
        }
    }
}
