using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using Polly.Timeout;

namespace Test.Thunders.Bootstrap.HttpHandlers;

public class RetryHttpHandler : DelegatingHandler
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly int _retryCount;
    private readonly int _timeout;

    public RetryHttpHandler(ILoggerFactory loggerFactory, int retryCount, int timeout)
    {
        _loggerFactory = loggerFactory;
        _retryCount = retryCount;
        _timeout = timeout;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return GetRetryPolicy().ExecuteAsync(() =>
                    GetTimeoutPolicy().ExecuteAsync(() =>
                        base.SendAsync(request, cancellationToken)));
    }
    private AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        var retryLogger = _loggerFactory.CreateLogger("PollyHttpRetryPoliciesLogger");

        return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrTransientHttpError()
                 .OrResult(msg => msg.StatusCode == HttpStatusCode.InternalServerError)
                 .OrResult(msg => msg.StatusCode == HttpStatusCode.GatewayTimeout)
                 .OrResult(msg => msg.StatusCode == HttpStatusCode.BadGateway)
                 .OrResult(msg => msg.StatusCode == HttpStatusCode.ServiceUnavailable)
                 .Or<TimeoutRejectedException>()
                 .WaitAndRetryAsync(
                    _retryCount,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(retryAttempt, 2)),
                    onRetry: (response, delay, retryCount, context) =>
                    {
                        using var act = Activity.Current;
                        if (response.Exception != null)
                        {
                            act.SetTag("exception.message", response.Exception.Message);
                            act.SetTag("exception.stack_trace", response.Exception.StackTrace);

                            retryLogger.LogError(response.Exception, $"Provider Error. Error Response Message: {response.Exception.Message}");
                            retryLogger.LogInformation("Sending again after Delay: {delay} - Attemp Number: {retryCount}", delay, retryCount);
                        }

                        retryLogger.LogInformation("Sending again after Delay: {delay} - Attemp Number: {retryCount}", delay, retryCount);
                    });
    }
    private AsyncTimeoutPolicy<HttpResponseMessage> GetTimeoutPolicy()
    {
        return Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(_timeout));
    }
}
