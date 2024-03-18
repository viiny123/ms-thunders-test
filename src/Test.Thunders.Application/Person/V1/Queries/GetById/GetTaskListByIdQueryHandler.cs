using System.Threading;
using System.Threading.Tasks;
using Test.Thunders.Application.Base;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;

namespace Test.Thunders.Application.Person.V1.Queries.GetById;

public class GetTaskListByIdQueryHandler : HandlerBase<GetTaskListByIdQuery>
{
    private readonly ITaskListRepository _taskListRepository;

    public GetTaskListByIdQueryHandler(ITaskListRepository taskListRepository)
    {
        _taskListRepository = taskListRepository;
    }

    public override async Task<Result> Handle(GetTaskListByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _taskListRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (entity is null)
        {
            Result.AddError(ErrorCatalog.TestError.GetByIdNotFound, ErrorCode.NotFound);

            return Result;
        }

        Result.Data = (GetTaskListByIdQueryResponse)entity;

        return Result;
    }
}
