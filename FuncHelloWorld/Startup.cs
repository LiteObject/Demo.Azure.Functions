using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(FuncHelloWorld.Startup))]
namespace FuncHelloWorld
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            Console.WriteLine(">>> HERE");

            /*Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Worker", LogEventLevel.Warning)
                .MinimumLevel.Override("Host", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Error)
                .MinimumLevel.Override("Function", LogEventLevel.Error)
                .MinimumLevel.Override("Azure.Storage.Blobs", LogEventLevel.Error)
                .MinimumLevel.Override("Azure.Core", LogEventLevel.Error)
                .Enrich.WithProperty("Application", "Comatic.KrediScan.AzureFunctions")
                .Enrich.FromLogContext()
                .WriteTo.DatadogLogs("XXXXXXXXXXX", configuration: new DatadogConfiguration() { Url = "https://http-intake.logs.datadoghq.eu" }, logLevel: LogEventLevel.Debug)
                .WriteTo.Console()
                .CreateLogger();

            builder.Services.AddSingleton<ILoggerProvider>(sp => new SerilogLoggerProvider(Log.Logger, true));

            builder.Services.AddLogging(lb =>
            {
                //lb.ClearProviders(); //--> if used nothing works...
                lb.AddSerilog(Log.Logger, true);
            }); */


        }
    }
}
