﻿using Booking.Notifications.Domain.Models;

namespace Booking.Notifications.Application.Repositories;

public interface INotificationRepository : IBaseRepository<NotificationTamplate>
{
    Task<NotificationTamplate> GetTemplateBySubjecteAsync(string subjecte);

    Task<NotificationTamplate> GetTemplateByIdAsync(string TemplateID);
}
