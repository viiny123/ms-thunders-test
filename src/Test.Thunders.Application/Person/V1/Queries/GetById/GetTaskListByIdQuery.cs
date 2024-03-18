using System;
using Test.Thunders.Application.Base;

namespace Test.Thunders.Application.Person.V1.Queries.GetById;

public class GetTaskListByIdQuery : QueryBase<GetTaskListByIdQuery>
{
    public Guid Id { get; set; }

    public GetTaskListByIdQuery(Guid id)
    {
        Id = id;
    }
}
