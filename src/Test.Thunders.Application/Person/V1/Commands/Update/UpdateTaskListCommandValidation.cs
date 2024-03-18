using FluentValidation;
using Test.Thunders.Application.Base.Extension;
using Test.Thunders.Application.Base.Error;

namespace Test.Thunders.Application.Person.V1.Commands.Update;

public class UpdateTaskListCommandValidation : AbstractValidator<UpdateTaskListCommand>
{
    public UpdateTaskListCommandValidation()
    {
        RuleFor(r => r)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.BaseInvalidRequest);
    }
}
