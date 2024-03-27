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

        public static string ReservationStatusNotification =>
            "Статус бронирования изменен.";

        public static string ReservationCanceledTemplate => @"
            Добрый день, @Model.FirstName @Model.LastName! <br/><br/>

            Ваше бронирование в @Model.FilialName отменено.<br/>

            C уважением, Entertiment Booking!
";


        public static string ReservationConfirmedTemplate => @"
            Добрый день, @Model.FirstName @Model.LastName!<br/><br/>

            Мы подтверждаем ваше бронирование в @Model.FilialName, <br/>
            по адресу: @Model.Address <br/>
            столик: @Model.TableName<br/><br/>

            C уважением, Entertiment Booking!
";

        public static string ReservationCreatedSubjectTemplate =>
            "Вы подали заявку на бронирование столика";

        public static string ReservationCreatedTemplate =>
            @"
            Добрый день, @Model.FirstName @Model.LastName!<br/><br/>

            Вы подали заявку на бронирование столика в @Model.FilialName, <br/>
            по адресу: @Model.Address <br/>
            столик: @Model.TableName <br/><br/>

            Период брони: @Model.From - @Model.To <br/><br/>

            C уважением, Entertiment Booking!
";
    }

        
}
