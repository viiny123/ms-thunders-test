using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Test.Thunders.Bootstrap.Providers.Options;

namespace Test.Thunders.Bootstrap.Providers;

[ExcludeFromCodeCoverage]
public static class MvcConfiguration
{
    public static IServiceCollection ConfigureMvcServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.Configure<JsonOptions>(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never);
        services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        services.AddRouting(options => options.LowercaseUrls = true);
        services.Configure<MvcOptions>(options =>
            options.Conventions.Add(new VersionPrefixConventionOption()));

        return services;
    }

    public static IApplicationBuilder ConfigureMvc(this IApplicationBuilder app)
    {
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());

        return app;
    }
}