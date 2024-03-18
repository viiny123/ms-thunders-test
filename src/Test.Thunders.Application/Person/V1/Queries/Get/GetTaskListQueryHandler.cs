using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Test.Thunders.Data.Extensions;
using Test.Thunders.Application.Base;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;

namespace Test.Thunders.Application.Person.V1.Queries.Get;

public class GetValueQueryHandler : HandlerBase<GetTaskListQuery>
{
    private readonly ITaskListRepository _taskListRepository;

    public GetValueQueryHandler(ITaskListRepository taskListRepository)
    {
        _taskListRepository = taskListRepository;
    }

    public override async Task<Result> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
    {
        var taskLists = await _taskListRepository.GetTaskListByFilter(new GetTaskListQueryDto
            {
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = request.Status
            })
            .Select<TaskList, GetTaskListQueryResponse>(x => x)
            .ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);

        Result.Data = taskLists;

        return Result;
    }
}
