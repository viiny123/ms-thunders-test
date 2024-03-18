using FluentValidation;
using Test.Thunders.Application.Base.Extension;
using Test.Thunders.Application.Base.Error;

namespace Test.Thunders.Application.Person.V1.Queries.GetById;

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
