using System.ComponentModel;

namespace Test.Thunders.Application.Base.Error;

public enum ErrorCode
{
    [Description("Malformed request syntax")]
    BadRequest = 0,

    [Description("Invalid user to use the resource")]
    Unauthorized = 1,

    [Description("The user is authorized to use the service, " +
                 "but not the requested resource")]
    Forbidden = 2,

    [Description("Requested resource could not be found or does not exist")]
    NotFound = 3,

    [Description("There is a resource with the same characteristics sent")]
    Conflict = 4,

    [Description("Validation of business rules executed")]
    UnprocessableEntity = 5,

    [Description("Unexpected error")]
    InternalServerError = 6,

    [Description("Integration service temporarily out of service")]
    ServiceUnavailable = 7
}