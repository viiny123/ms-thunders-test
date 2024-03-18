using System;
using System.IO;
using Test.Thunders.Bootstrap.Providers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Test.Thunders.API;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var config = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: true)
                     .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                     .AddEnvironmentVariables()
                     .AddCommandLine(args)
                     .Build();

        LogConfiguration.ConfigureLogger(config, environment);

        return Host.CreateDefaultBuilder(args)
                   .UseSerilog()
                   .ConfigureLogging(x => x.AddConsole())
                   .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
