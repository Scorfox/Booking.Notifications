namespace Booking.Notifications.WebAPI.Options;

public class MailOptions
{
    public static string Key = "Jwt";

    public string Mail { get; set; }

    public string DisplayName { get; set; }

    public string Password { get; set; }
    
    public int Port { get; set; }

    public string Host { get; set; }
}
