using MediatR;
using Microsoft.AspNetCore.Http;

namespace Booking.Notifications.Application.Features.NotificationFeatures;

public sealed record NotificationRequest : IRequest<bool>
{
    public string ToEmail { get; set; }
    public Guid TemplateId { get; set; }
}
