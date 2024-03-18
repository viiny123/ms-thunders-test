using System;
using Test.Thunders.Domain.Base;

namespace Test.Thunders.Domain.AggregatesModel.TaskAggregate;

public class TaskList : EntityBase<TaskList>
{
    public string Description { get; set; }
    public Status Status { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
}
