using FluentValidation;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.Application.Base.Extension;

namespace Test.Thunders.Application.TaskLists.V1.Queries.GetById;

public class GetTaskListByIdQueryValidation : AbstractValidator<GetTaskListByIdQuery>
{
    public GetTaskListByIdQueryValidation()
    {
        RuleFor(r => r)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.BaseInvalidRequest);

        RuleFor(r => r.Id)
            .NotEmpty()
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.GetByIdNotFound);
    }
}
