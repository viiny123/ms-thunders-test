using Test.Thunders.Application.Person.V1.Commands.Update;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;

namespace Test.Thunders.API.Controllers.TaskLists.V1.Update;

public class UpdateTaskListRequest
{
    public string Description { get; set; }
    public Status Status { get; set; }

    public static implicit operator UpdateTaskListCommand(UpdateTaskListRequest request)
    {
        return new UpdateTaskListCommand
        {
            Description = request.Description,
            Status = request.Status
        };
    }
}
