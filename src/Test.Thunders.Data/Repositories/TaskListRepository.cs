using System;
using System.Globalization;
using System.Linq;
using Test.Thunders.Data.Base;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;

namespace Test.Thunders.Data.Repositories;

public class TaskListRepository : RepositoryBase<TestDbContext, TaskList>, ITaskListRepository
{
    public TaskListRepository(TestDbContext context) : base(context)
    {
    }

    public IQueryable<TaskList> GetTaskListByFilter(GetTaskListQueryDto taskListQueryDto)
    {
        var query = GetDbSetQuery();

        if (taskListQueryDto.StartDate.HasValue)
        {
            query = query.Where(x => x.CreateAt.Date >= taskListQueryDto.StartDate.Value.Date);
        }

        if (taskListQueryDto.EndDate.HasValue)
        {
            query = query.Where(x => x.CreateAt.Date <= taskListQueryDto.EndDate.Value.Date);
        }

        if(taskListQueryDto.Status.HasValue)
        {
            query = query.Where(x => x.Status == taskListQueryDto.Status);
        }

        if (string.IsNullOrWhiteSpace(taskListQueryDto.Description) is false)
        {
            query = query.Where(x => x.Description.Contains(taskListQueryDto.Description));
        }

        query = query.OrderBy(x => x.Description);

        return query;
    }
}
