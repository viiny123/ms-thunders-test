using System;

namespace Test.Thunders.Domain.AggregatesModel.TaskAggregate;

public class GetTaskListQueryDto
{
    public string Description { get; set; }
    public Status? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
