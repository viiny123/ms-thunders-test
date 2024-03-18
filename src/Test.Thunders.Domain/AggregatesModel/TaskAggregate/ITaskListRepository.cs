using System.Linq;
using Test.Thunders.Domain.Base;

namespace Test.Thunders.Domain.AggregatesModel.TaskAggregate;

public interface ITaskListRepository : IRepositoryBase<TaskList>
{
    IQueryable<TaskList> GetTaskListByFilter(GetTaskListQueryDto taskListQueryDto);
}
