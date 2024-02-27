using Booking.Notifications.Application.Features.NotificationFeatures;
using Booking.Notifications.Application.Repositories;
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
        private readonly INotificationRepository _notificationRepository;

        public NotificationController(IMediator mediator, INotificationService notificationService, INotificationRepository notificationRepository)
        {
            _mediator = mediator;
            _notificationService = notificationService;
            _notificationRepository = notificationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SendBookingConfirmation(NotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                if (result)
                    return Ok("Сообщение отправлено");
                else
                    return BadRequest("Не удалось отправить сообщение");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Произошла ошибка: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTemplate(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _notificationRepository.GetAll(cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
