using System;
using Test.Thunders.Application.Base;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;

namespace Test.Thunders.Application.Person.V1.Queries.Get;

public class GetTaskListQuery : QueryBase<GetTaskListQuery>
{
    public string Description { get; set; }
    public Status? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public GetTaskListQuery(
        string description,
        Status? status,
        DateTime? startDate,
        DateTime? endDate)
    {
        Description = description;
        Status = status;
        StartDate = startDate;
        EndDate = endDate;
    }

    public GetTaskListQuery WithPaginated(int pageSize, int pageNumber)
    {
        PageNumber = pageNumber;
        PageSize = pageSize > 10 ? 10 : pageSize;

        return this;
    }
}
