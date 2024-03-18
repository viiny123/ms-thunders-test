using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Enrichers.Span;

namespace Test.Thunders.Bootstrap.Providers;

public static class LogConfiguration
{
    public static void ConfigureLogger(IConfiguration config, string env)
    {
        var loggerConfiguration = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithSpan(new SpanOptions
            {
                IncludeBaggage = true,
                IncludeOperationName = true,
                IncludeTags = true,
                LogEventPropertiesNames = new SpanLogEventPropertiesNames
                {
                    SpanId = "span.id",
                    ParentId = "parent.id",
                    TraceId = "trace.id"
                }
            })
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentName()
            .Enrich.WithSpan()
            .Filter.ByIncludingOnly(x =>
                !x.Properties.TryGetValue("RequestPath", out var path) ||
                !path.ToString().Contains("/ping"))
            .ReadFrom.Configuration(config);

        Log.Logger = loggerConfiguration.CreateLogger();
    }
}
