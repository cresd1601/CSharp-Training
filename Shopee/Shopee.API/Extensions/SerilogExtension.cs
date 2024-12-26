using Serilog;

namespace Shopee.API.Extensions
{
    public static class SerilogExtension
    {
        public static void AddSerilogConfig(this ILoggingBuilder logging)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/Shopee_Log.txt", rollingInterval: RollingInterval.Day)
                .MinimumLevel.Information()
                .CreateLogger();

            logging.ClearProviders();
            logging.AddSerilog(logger);
        }
    }
}