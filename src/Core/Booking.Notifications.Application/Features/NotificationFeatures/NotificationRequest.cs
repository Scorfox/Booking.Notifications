using MediatR;
using Microsoft.AspNetCore.Http;

namespace Booking.Notifications.Application.Features.NotificationFeatures;

public sealed record NotificationRequest : IRequest<bool>
{
    public string FromEmail { get; set; }

    public string Subjecte { get; set; }
}
