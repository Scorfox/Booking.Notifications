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

        [HttpPost("�������������")]
        public async Task<IActionResult> SendBookingConfirmation(NotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                if (result)
                {
                    return Ok(_notificationService.SendMailAsync("������������� ������ ������������", request.FromEmail));
                }
                else
                {
                    return BadRequest("�� ������� ��������� ���������");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"��������� ������: {ex.Message}");
            }
        }

        [HttpPost("�����������")]
        public async Task<IActionResult> SendBookingUpcoming(NotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                if (result)
                {
                    return Ok(_notificationService.SendMailAsync("����������� � ����� ������������", request.FromEmail));
                }
                else
                {
                    return BadRequest("�� ������� ��������� �����������");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"��������� ������: {ex.Message}");
            }
        }

        [HttpPost("�������������")]
        public async Task<IActionResult> SendThanksForVisiting(NotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                if (result)
                {
                    return Ok(_notificationService.SendMailAsync("������� �� ���� ���������", request.FromEmail));
                }
                else
                {
                    return BadRequest("�� ������� ��������� �����������");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"��������� ������: {ex.Message}");
            }
        }

        [HttpPost("������ �������")]
        public async Task<IActionResult> SendAssessmentService(NotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                if (result)
                {
                    return Ok(_notificationService.SendMailAsync("������� �� ���� ���������", request.FromEmail));
                }
                else
                {
                    return BadRequest("�� ������� ��������� �����������");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"��������� ������: {ex.Message}");
            }
        }
    }
}
