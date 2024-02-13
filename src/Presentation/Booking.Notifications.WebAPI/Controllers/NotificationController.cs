using Booking.Notifications.Application.Features.NotificationFeatures;
using Booking.Notifications.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Booking.Notifications.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly INotificationService _notificationService;

        public NotificationController(IMediator mediator, INotificationService notificationService)
        {
            _mediator = mediator;
            _notificationService = notificationService;
        }

        [HttpPost("Подтверждение")]
        public async Task<IActionResult> SendBookingConfirmation(NotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                if (result)
                {
                    return Ok(_notificationService.SendMailAsync("Подтверждение вашего бронирования", request.FromEmail));
                }
                else
                {
                    return BadRequest("Не удалось отправить сообщение");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Произошла ошибка: {ex.Message}");
            }
        }

        [HttpPost("Напоминание")]
        public async Task<IActionResult> SendBookingUpcoming(NotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                if (result)
                {
                    return Ok(_notificationService.SendMailAsync("Напоминание о вашем бронировании", request.FromEmail));
                }
                else
                {
                    return BadRequest("Не удалось отправить уведомление");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Произошла ошибка: {ex.Message}");
            }
        }

        [HttpPost("Благодарность")]
        public async Task<IActionResult> SendThanksForVisiting(NotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                if (result)
                {
                    return Ok(_notificationService.SendMailAsync("Спасибо за ваше посещение", request.FromEmail));
                }
                else
                {
                    return BadRequest("Не удалось отправить уведомление");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Произошла ошибка: {ex.Message}");
            }
        }

        [HttpPost("Оценка сервиса")]
        public async Task<IActionResult> SendAssessmentService(NotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                if (result)
                {
                    return Ok(_notificationService.SendMailAsync("Спасибо за ваше посещение", request.FromEmail));
                }
                else
                {
                    return BadRequest("Не удалось отправить уведомление");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
