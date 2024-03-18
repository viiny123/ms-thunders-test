using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Test.Thunders.Bootstrap.Middlewares;

namespace Test.Thunders.Bootstrap.Providers;

[ExcludeFromCodeCoverage]
public static class MiddlewareConfiguration
{
    public static IApplicationBuilder ConfigureMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionErrorMiddleware>();

        return app;
    }
}