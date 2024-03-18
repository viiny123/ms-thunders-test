using FluentValidation;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.Application.Base.Extension;

namespace Test.Thunders.Application.TaskLists.V1.Commands.Update;

public class UpdateTaskListCommandValidation : AbstractValidator<UpdateTaskListCommand>
{
    public UpdateTaskListCommandValidation()
    {
        RuleFor(r => r)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.BaseInvalidRequest);
    }
}
