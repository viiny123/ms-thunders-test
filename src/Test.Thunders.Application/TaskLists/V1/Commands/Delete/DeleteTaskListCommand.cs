using System;
using Test.Thunders.Application.Base;

namespace Test.Thunders.Application.TaskLists.V1.Commands.Delete;

public class DeleteTaskListCommand : CommandBase<DeleteTaskListCommand>
{
    public Guid Id { get; set; }
}
