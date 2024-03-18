using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Thunders.Application.Base;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;
using Test.Thunders.Domain.Base;

namespace Test.Thunders.Application.TaskLists.V1.Commands.Delete;

public class DeletePersonCommandHandler : HandlerBase<DeleteTaskListCommand>
{
    private readonly ITaskListRepository _taskListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePersonCommandHandler(ITaskListRepository taskListRepository,
        IUnitOfWork unitOfWork)
    {
        _taskListRepository = taskListRepository;
        _unitOfWork = unitOfWork;
    }

    public override async Task<Result> Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
    {
        await _taskListRepository
            .GetDbSet()
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);

        return Result;
    }
}
