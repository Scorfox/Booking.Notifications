using Booking.Notifications.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Notifications.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : Controller
    {
        public readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> Send(MailRequest mailRequest)
        {
            try
            {
                await _notificationService.SendMailAsync(mailRequest);
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
