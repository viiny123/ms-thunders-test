using FluentValidation;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.Application.Base.Extension;

namespace Test.Thunders.Application.TaskLists.V1.Commands.Create;

public class CreateTaskListCommandValidation : AbstractValidator<CreateTaskListCommand>
{
    public CreateTaskListCommandValidation()
    {
        RuleFor(r => r)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.BaseInvalidRequest);

        RuleFor(r => r.Description)
            .NotEmpty()
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.CreateOrUpdateDescriptionIsNullOrEmpty);

    }
}
