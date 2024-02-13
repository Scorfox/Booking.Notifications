using Booking.Notifications.Application.Features.NotificationFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Notifications.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Default")]
        public async Task<IActionResult> Send(NotificationRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                if (result)
                {
                    return Ok("Уведомление успешно отправлено");
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

        [HttpPost("Подтверждение")]
        public async Task<IActionResult> SendBookingConfirmation(NotificationRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                if (result)
                {
                    return Ok("Уведомление успешно отправлено");
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

        [HttpPost("Напоминание")]
        public async Task<IActionResult> SendBookingUpcoming(NotificationRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                if (result)
                {
                    return Ok("Уведомление успешно отправлено");
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
        public async Task<IActionResult> SendThanksForVisiting(NotificationRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                if (result)
                {
                    return Ok("Уведомление успешно отправлено");
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
        public async Task<IActionResult> SendAssessmentService(NotificationRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                if (result)
                {
                    return Ok("Уведомление успешно отправлено");
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
