using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Notification.API;
using Notification.API.Interface;
using Notification.API.Models;

namespace Notification.Controllers
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
