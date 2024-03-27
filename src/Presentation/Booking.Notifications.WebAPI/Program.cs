using Booking.Notifications.WebAPI;
using Serilog;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        try
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
                .Build();
            Log.Logger  = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
    
            Log.Information("Application is starting!");
    
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseSerilog();
            var startup = new Startup(builder.Configuration);
            
            startup.ConfigureServices(builder.Services);
            var app = builder.Build();
            
            startup.Configure(app, builder.Environment);
            await app.RunAsync();
    
            Log.Information("Application stopped!");
            
            return 0;
            
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
            return 1;
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }
}