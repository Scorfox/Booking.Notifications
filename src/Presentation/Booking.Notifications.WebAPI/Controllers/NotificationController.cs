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
                    return Ok("����������� ������� ����������");
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
        public async Task<IActionResult> SendBookingConfirmation(NotificationRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                if (result)
                {
                    return Ok("����������� ������� ����������");
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

        [HttpPost("�����������")]
        public async Task<IActionResult> SendBookingUpcoming(NotificationRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                if (result)
                {
                    return Ok("����������� ������� ����������");
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
        public async Task<IActionResult> SendThanksForVisiting(NotificationRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                if (result)
                {
                    return Ok("����������� ������� ����������");
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
        public async Task<IActionResult> SendAssessmentService(NotificationRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                if (result)
                {
                    return Ok("����������� ������� ����������");
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
