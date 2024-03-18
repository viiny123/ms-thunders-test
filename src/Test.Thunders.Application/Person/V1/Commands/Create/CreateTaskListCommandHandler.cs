using System.Threading;
using System.Threading.Tasks;
using Test.Thunders.Domain.Base;
using Test.Thunders.Application.Base;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;

namespace Test.Thunders.Application.Person.V1.Commands.Create;

public class CreateTaskListCommandHandler : HandlerBase<CreateTaskListCommand>
{
    private readonly ITaskListRepository _taskListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskListCommandHandler(
        ITaskListRepository taskListRepository,
        IUnitOfWork unitOfWork)
    {
        _taskListRepository = taskListRepository;
        _unitOfWork = unitOfWork;
    }

    public override async Task<Result> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
    {
        var entity = (TaskList)request;

        await _taskListRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();

        Result.Data = (CreateTaskListResponse)entity;

        return Result;
    }
}
