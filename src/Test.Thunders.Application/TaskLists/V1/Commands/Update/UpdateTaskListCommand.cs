using System;
using Test.Thunders.Application.Base;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;

namespace Test.Thunders.Application.TaskLists.V1.Commands.Update;

public class UpdateTaskListCommand : CommandBase<UpdateTaskListCommand>
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
}
