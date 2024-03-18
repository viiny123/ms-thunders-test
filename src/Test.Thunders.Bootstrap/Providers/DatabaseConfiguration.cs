using System.Diagnostics.CodeAnalysis;
using Test.Thunders.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Thunders.Bootstrap.Providers;

[ExcludeFromCodeCoverage]
public static class DatabaseBootstrap
{
    public static IServiceCollection ConfigureDatabases(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TestDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("Test.Thunders.Data")));

        return services;
    }

    public static IApplicationBuilder RunMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices
                                    .GetRequiredService<IServiceScopeFactory>()
                                    .CreateScope();

        using var context = serviceScope.ServiceProvider.GetService<TestDbContext>();
        context.Database.Migrate();

        return app;
    }
}
