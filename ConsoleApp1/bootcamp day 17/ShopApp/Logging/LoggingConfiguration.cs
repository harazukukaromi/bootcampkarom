using Serilog;
using Serilog.Events;

namespace ShopApp.Logging
{
    public static class LoggingConfiguration
    {
        public static void InitializeLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(
                    path: "Logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                // ✅ Tambahkan SQLite sink
                .WriteTo.SQLite(
                    sqliteDbPath: "Logs/logs.db",        // lokasi database log
                    tableName: "LogEvents",               // nama tabel
                    storeTimestampInUtc: false)           // simpan waktu lokal
                .CreateLogger();
        }
    }
}
