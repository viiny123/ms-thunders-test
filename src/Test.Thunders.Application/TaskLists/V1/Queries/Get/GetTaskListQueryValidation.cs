using FluentValidation;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.Application.Base.Extension;

namespace Test.Thunders.Application.TaskLists.V1.Queries.Get;

public class GetTaskListQueryValidation : AbstractValidator<GetTaskListQuery>
{
    public GetTaskListQueryValidation()
    {
        RuleFor(r => r)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.BaseInvalidRequest);
    }
}
