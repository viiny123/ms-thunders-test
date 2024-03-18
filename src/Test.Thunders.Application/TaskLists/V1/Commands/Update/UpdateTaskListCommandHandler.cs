using System.Threading;
using System.Threading.Tasks;
using Test.Thunders.Application.Base;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;
using Test.Thunders.Domain.Base;

namespace Test.Thunders.Application.TaskLists.V1.Commands.Update;

public class UpdateTaskListCommandHandler : HandlerBase<UpdateTaskListCommand>
{
    private readonly ITaskListRepository _taskListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTaskListCommandHandler(ITaskListRepository taskListRepository,
        IUnitOfWork unitOfWork)
    {
        _taskListRepository = taskListRepository;
        _unitOfWork = unitOfWork;
    }

    public override async Task<Result> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _taskListRepository
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (entity is null)
        {
            Result.AddError(ErrorCatalog.TestError.GetByIdNotFound, ErrorCode.NotFound);

            return Result;
        }

        entity.Description = request.Description;
        entity.Status = request.Status;

        await _taskListRepository.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();

        return Result;
    }
}
