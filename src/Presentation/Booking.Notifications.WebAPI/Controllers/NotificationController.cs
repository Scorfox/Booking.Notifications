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
            if (request.Subjecte != "1")
                return Conflict();

                request.Subjecte = "Подтверждение вашего бронирования";
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                if (result)
                {
                    return Ok("Сообщение отправлено");
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
            if (request.Subjecte != "2")
                return Conflict();
            else
                request.Subjecte = "Напоминание о вашем бронировании";
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                if (result)
                {
                    return Ok("Сообщение отправлено");
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
            if (request.Subjecte != "3")
                return Conflict();
            else
                request.Subjecte = "Спасибо за ваше посещение";
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                if (result)
                {
                    return Ok("Сообщение отправлено");
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
