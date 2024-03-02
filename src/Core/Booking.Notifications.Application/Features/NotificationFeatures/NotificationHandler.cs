using Booking.Notifications.Application.Repositories;
using Booking.Notifications.Domain.Interfaces;
using MediatR;

namespace Booking.Notifications.Application.Features.NotificationFeatures;

public sealed class NotificationHandler : IRequestHandler<NotificationRequest, bool>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly INotificationService _notificationService;

    public NotificationHandler (INotificationRepository notificationRepository, INotificationService notificationService)
    {
        _notificationRepository = notificationRepository;
        _notificationService = notificationService;
    }

    public async Task<bool> Handle(NotificationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var tamplate = await _notificationRepository.GetTemplateByIdAsync(request.TemplateId);
            if (tamplate == null)
            {
                throw new Exception($"Шаблон {request.TemplateId} не найден.");
            }

            // Заменяем переменные в теле сообщения, если необходимо
            var processedBody = tamplate.Body;

            // Отправляем письмо
            // Требуется изменение под использование processedBody
            return await _notificationService.SendMailAsync(request.ToEmail, tamplate.Subject, tamplate.Body);
        }
        catch (Exception ex)
        {
            // Обработка ошибок отправки
            Console.WriteLine($"Error sending email notification: {ex.Message}");
            return false;
        }
    }
}
