using System.Diagnostics.CodeAnalysis;
using Test.Thunders.Bootstrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Thunders.API;

[ExcludeFromCodeCoverage]
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureServices(Configuration);
    }

    public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
    {
        app.Configure(Configuration, provider);
    }
}
