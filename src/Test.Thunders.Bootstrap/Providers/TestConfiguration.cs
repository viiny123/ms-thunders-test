using System.Diagnostics.CodeAnalysis;
using Test.Thunders.Data.Base;
using Test.Thunders.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Thunders.Bootstrap.HttpHandlers;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;
using Test.Thunders.Domain.Base;

namespace Test.Thunders.Bootstrap.Providers;

[ExcludeFromCodeCoverage]
public static class TestConfiguration
{
    public static IServiceCollection ConfigureTestModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITaskListRepository, TaskListRepository>();
        services.AddTransient<FailHttpLoggerHandler>();

        return services;
    }
}
