using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Test.Thunders.Bootstrap.Providers;

[ExcludeFromCodeCoverage]
public static class HealthCheckConfiguration
{
    public static IServiceCollection ConfigureHealthCheck(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddCheck("ms-thunders", () => HealthCheckResult.Healthy(), tags: new string[] { "service" })
            .AddSqlServer(
                configuration.GetConnectionString("Default"),
                name: "sqlserver",
                tags: new string[] { "db", "database" });

        return services;
    }

    public static IApplicationBuilder ConfigureHealthCheck(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/ping",
            new HealthCheckOptions()
            {
                ResponseWriter = WritePongResultAsync
            });

        app.UseHealthChecks(
            "/pong-ui",
            new HealthCheckOptions()
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

        return app;
    }

    private static async Task WritePongResultAsync(
        HttpContext context,
        HealthReport report)
    {
        var pongResult = report.Entries
              .OrderBy(x => x.Value.Status)
              .Select(x => new
              {
                  Resource = x.Key,
                  Status = x.Value.Status.ToString(),
                  x.Value.Tags,
                  ExceptionMessage = x.Value.Exception?.Message,
                  x.Value.Exception?.StackTrace
              });

        context.Response.ContentType = MediaTypeNames.Application.Json;

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(
                pongResult,
                options: new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = { new JsonStringEnumConverter() }
                }));
    }
}
