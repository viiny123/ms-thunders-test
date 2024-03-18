using FluentValidation;
using Test.Thunders.Application.Base.Extension;
using Test.Thunders.Application.Base.Error;

namespace Test.Thunders.Application.Person.V1.Commands.Create;

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
