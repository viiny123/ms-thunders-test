using System.Net;
using Microsoft.AspNetCore.Mvc;
using Test.Thunders.Application.Base;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.CrossCutting.Extensions;


namespace Test.Thunders.API.Presenters;

public static class BasePresenter
{
    public static IActionResult Cast(object result, HttpStatusCode statusCode)
    {
        return Cast(new Result { Data = result }, statusCode);
    }

    public static IActionResult Cast(Result result, HttpStatusCode statusCode)
    {
        if (result.Error.HasValue)
        {
            return result.Error.Value
                switch
                {
                    ErrorCode.NotFound => new NotFoundObjectResult(GetError(result)),
                    ErrorCode.UnprocessableEntity => new UnprocessableEntityObjectResult(GetError(result)),
                    ErrorCode.Unauthorized => new UnauthorizedObjectResult(GetError(result)),
                    ErrorCode.InternalServerError => new ObjectResult(GetError(result))
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    },
                    _ => new BadRequestObjectResult(GetError(result)),
                };
        }
        else
        {
            return statusCode
                switch
                {
                    HttpStatusCode.OK => new OkObjectResult(result.Data),
                    HttpStatusCode.Created => new CreatedResult(string.Empty, result.Data),
                    HttpStatusCode.NoContent => new NoContentResult(),
                    HttpStatusCode.Accepted => new AcceptedResult(string.Empty, result.Data),
                    _ => new OkResult()
                };
        }
    }

    public static ResponseError<ErrorDetail> GetError(Result result)
    {
        return new ResponseError<ErrorDetail>(result.Error,
            result.Errors,
            result.Error.GetDescription());
    }
}
