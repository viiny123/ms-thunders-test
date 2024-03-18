using System;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;

namespace Test.Thunders.Application.Person.V1.Queries.Get;

public class GetTaskListQueryResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public DateTime CreateAt { get; set; }

    public static implicit operator GetTaskListQueryResponse(TaskList taskList) => new()
    {
        Id = taskList.Id,
        Description = taskList.Description,
        Status = taskList.Status,
        CreateAt = taskList.CreateAt
    };
}
