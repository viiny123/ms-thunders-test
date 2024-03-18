using FluentValidation;
using Test.Thunders.Application.Base.Extension;
using Test.Thunders.Application.Base.Error;

namespace Test.Thunders.Application.Person.V1.Queries.Get;

public class GetTaskListQueryValidation : AbstractValidator<GetTaskListQuery>
{
    public GetTaskListQueryValidation()
    {
        RuleFor(r => r)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.BaseInvalidRequest);
    }
}
