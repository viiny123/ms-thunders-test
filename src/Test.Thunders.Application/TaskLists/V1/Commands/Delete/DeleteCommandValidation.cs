using FluentValidation;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.Application.Base.Extension;
using Test.Thunders.Application.TaskLists.V1.Commands.Update;

namespace Test.Thunders.Application.TaskLists.V1.Commands.Delete;

public class DeleteTaskListCommandValidation : AbstractValidator<UpdateTaskListCommand>
{
    public DeleteTaskListCommandValidation()
    {
        RuleFor(r => r)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.BaseInvalidRequest);

        RuleFor(r => r.Id)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.DeleteIdIsNullOrEmpty);
    }
}
