using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Test.Thunders.Application.Base;
using Test.Thunders.Application.Base.Error;

namespace Test.Thunders.Bootstrap.Providers.Pipelines;

public sealed class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TResponse : Result, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var errorCode = ErrorCode.BadRequest;
        var erros = _validators
                    .Select(v => v.Validate(request))
                    .SelectMany(result => result.Errors)
                    .Where(f => f != null)
                    .ToList();
        return erros.Any() ? ErrorHandlerAsync(erros, errorCode) : next();
    }

    private static async Task<TResponse> ErrorHandlerAsync(IEnumerable<ValidationFailure> validationFail,
        ErrorCode errorCode)
    {
        var response = new TResponse();

        response.AddValidationErrors(validationFail.Select(a => new ErrorCatalogEntry(a.ErrorCode,
            a.ErrorMessage,
            a.PropertyName)).ToList(), errorCode);

        return await Task.FromResult(response);
    }
}