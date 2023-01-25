using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.IO;

[assembly: FunctionsStartup(typeof(FuncHelloWorld.Startup))]
namespace FuncHelloWorld
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            IConfiguration appConfig = builder.GetContext().Configuration;

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(appConfig, sectionName: "Serilog")
                /*.MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.DatadogLogs("<API_KEY>",
                    configuration: new DatadogConfiguration()
                    {
                        Url = "https://http-intake.logs.datadoghq.com"
                    },
                    logLevel: LogEventLevel.Debug,
                    service: "mx-local-svc",
                    host: "mx-local-host"
                    )
                .WriteTo.Console()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day) */
                .CreateLogger();

            //builder.Services.AddSingleton<ILoggerProvider>(sp => new SerilogLoggerProvider(Log.Logger, true));

            _ = builder?.Services.AddLogging(lb =>
            {
                //lb.ClearProviders();
                _ = lb.AddSerilog(Log.Logger, true);
            });

        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            FunctionsHostBuilderContext context = builder.GetContext();

            _ = builder?.ConfigurationBuilder
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, "appsettings.json"), optional: true, reloadOnChange: false)
                // .AddJsonFile(Path.Combine(context.ApplicationRootPath, $"appsettings.{context.EnvironmentName}.json"), optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();
        }
    }
}
