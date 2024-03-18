using Test.Thunders.Application.Base;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;

namespace Test.Thunders.Application.TaskLists.V1.Commands.Create;

public class CreateTaskListCommand : CommandBase<CreateTaskListCommand>
{
    public string Description { get; set; }

    public static implicit operator TaskList(CreateTaskListCommand command) => new()
    {
        Description = command.Description,
        Status = Status.Opened
    };
}
