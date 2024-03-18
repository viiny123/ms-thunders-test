using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refit;
using Test.Thunders.Application.Services.ViaCep.API;
using Test.Thunders.Bootstrap.HttpHandlers;
using Test.Thunders.Bootstrap.Providers.Options;

namespace Test.Thunders.Bootstrap.Providers;

public static class HttpClientConfiguration
{
    public static IServiceCollection ConfigureHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        //TODO: vou deixar de exemplo para mostrar como configuro um cliente http com refit.
        // services.AddRefitClient<IViaCepApi>(RefitSettingsOption.DefaultSettings())
        //         .ConfigureHttpClient(c =>
        //         {
        //             c.BaseAddress = new Uri(configuration.GetValue<string>("ViaCepApi:BaseAddress"));
        //         })
        //         .AddHttpMessageHandler<FailHttpLoggerHandler>()
        //         .AddHttpMessageHandler(provider =>
        //             new RetryHttpHandler(
        //                 provider.GetRequiredService<ILoggerFactory>(),
        //                 configuration.GetValue<int>("ViaCepApi:Resilience:RetryCount"),
        //                 configuration.GetValue<int>("ViaCepApi:Resilience:Timeout")));

        return services;
    }
}
