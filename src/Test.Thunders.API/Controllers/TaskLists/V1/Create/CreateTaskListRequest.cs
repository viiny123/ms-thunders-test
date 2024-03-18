using Test.Thunders.Application.Person.V1.Commands.Create;

namespace Test.Thunders.API.Controllers.TaskLists.V1.Create;

public class CreateTaskListRequest
{
    public string Description { get; set; }

    public static implicit operator CreateTaskListCommand(CreateTaskListRequest request)
    {
        return new CreateTaskListCommand
        {
            Description = request.Description
        };
    }
}
