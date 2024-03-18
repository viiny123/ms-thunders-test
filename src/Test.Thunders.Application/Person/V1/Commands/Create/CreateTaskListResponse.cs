using System;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;

namespace Test.Thunders.Application.Person.V1.Commands.Create;

public class CreateTaskListResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public DateTime CreateAt { get; set; }

    public static implicit operator CreateTaskListResponse(TaskList entity) => new()
    {
        Id = entity.Id,
        Description = entity.Description,
        Status = entity.Status,
        CreateAt = entity.CreateAt
    };
}
