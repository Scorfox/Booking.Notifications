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
            var template = await _notificationRepository.GetTemplateBySubjecteAsync(request.Subjecte, cancellationToken);
            if (template == null)
            {
                throw new Exception($"Шаблон {request.Subjecte} не найден.");
            }

            // Заменяем переменные в теле сообщения, если необходимо
            var processedBody = template.Body;

            // Отправляем письмо
            // Требуется изменение под использование processedBody
            return await _notificationService.SendMailAsync(request.FromEmail, template.Subject);
        }
        catch (Exception ex)
        {
            // Обработка ошибок отправки
            Console.WriteLine($"Error sending email notification: {ex.Message}");
            return false;
        }
    }
}
