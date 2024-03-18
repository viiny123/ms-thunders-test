using System.Collections.Generic;
using System.Linq;
using Test.Thunders.Application.Base.Error;

namespace Test.Thunders.Application.Base;

public class Result
{
    private readonly List<ErrorDetail> _errors;
    public IReadOnlyCollection<ErrorDetail> Errors => _errors;
    public ErrorCode? Error { get; set; }
    public object Data { get; set; }
    public bool IsValid => Errors.Any() == false;

    public Result()
    {
        _errors = new List<ErrorDetail>();
    }

    public void AddError(ErrorCatalogEntry errorCatalogEntry, ErrorCode errorCode)
    {
        Error = errorCode;
        _errors.Add(new ErrorDetail(errorCatalogEntry.Code, errorCatalogEntry.Message));
    }

    public void AddValidationErrors(IEnumerable<ErrorCatalogEntry> errorCatalogEntry, ErrorCode errorCode)
    {
        Error = errorCode;
        _errors.AddRange(errorCatalogEntry.Select(x => new ErrorDetail(x.Code, x.Message, x.Property)));
    }
}