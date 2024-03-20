using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Notifications.Domain.NotificationsTemplates
{
    public record UserNotificationsTemplates
    {
        public static string UserCreatedBodyTemplate => @"
            Добрый день @Model.Name @Model.LastName!

            Вы успешно зарегистрировались в системе Booking Entertaimont.

            Ваш логином: @Model.Login.
        ";

        public static string UserCreatedSubjectTemplate =>
            "Вы успешно зарегистрировались в системе Booking Entertaimont.";
    }
}
