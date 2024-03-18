using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Elastic.Apm;
using Elastic.Apm.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.CrossCutting.Extensions;

namespace Test.Thunders.Bootstrap.Middlewares;

public class ExceptionErrorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionErrorMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    private static readonly JsonSerializerOptions JSON_SERIALIZER_SETTINGS = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter() }
    };

    public ExceptionErrorMiddleware(RequestDelegate next,
        ILogger<ExceptionErrorMiddleware> logger,
        IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var transaction = Agent.Tracer.CurrentTransaction;

        try
        {
            httpContext.Response.Headers.Add("x-trace-id", transaction?.TraceId);
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex, transaction);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context,
        Exception exception,
        ITransaction transaction)
    {

        var unexpectedError = new ResponseError<UnexpectedError>(ErrorCode.InternalServerError,
            new List<UnexpectedError> { new UnexpectedError(exception, _env.IsDevelopment()) },
            ErrorCode.InternalServerError.GetDescription());

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var errorJsonContent = JsonSerializer.Serialize(unexpectedError, options: JSON_SERIALIZER_SETTINGS);

        transaction?.CaptureException(exception);

        _logger.LogError("{error.exception}", errorJsonContent);
        _logger.LogError(exception, "Unexpected error");

        await context.Response.WriteAsync(errorJsonContent);
    }
}
